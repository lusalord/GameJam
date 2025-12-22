using System;
using System.Collections;
using System.Collections.Generic;
using KBG.Script.Enemy;
using KBG.Script.Manager.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KBG.Script.Manager
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private List<WaveData> waveData;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private SpawnData data;
        
        private int _currentWaveIndex = 0;
        private int _currentEnemyIndex = 0;

        private GameObject _enemyParent;
        
        private void Awake()
        {
            Screen.SetResolution(1920, 1080, true);
        }

        private void Start()
        {
            _enemyParent = new GameObject("=======Enemy=======");
            StartCoroutine(EnemySpawn());
        }

        private Vector2 RandomSpawnPosition()
        {
            Vector2 spawnPoint;
            Vector2 spawnAreaMinXY = (Vector2)Camera.main.transform.position - data.spawnAreaSize/2;
            Vector2 spawnAreaMaxXY = (Vector2)Camera.main.transform.position + data.spawnAreaSize/2;
            Vector2 camMinXY = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector2 camMaxXY = Camera.main.ViewportToWorldPoint(Vector3.one);
            int spawnMethod = Random.Range(0, 4);
            switch (spawnMethod)
            {
                case 0:
                    spawnPoint.x = Random.Range(camMinXY.x, spawnAreaMaxXY.x);
                    spawnPoint.y = Random.Range(camMaxXY.y, spawnAreaMaxXY.y);
                    break;
                case 1:
                    spawnPoint.x = Random.Range(camMaxXY.x, spawnAreaMaxXY.x);
                    spawnPoint.y = Random.Range(spawnAreaMinXY.y, camMaxXY.y);
                    break;
                case 2:
                    spawnPoint.x = Random.Range(spawnAreaMinXY.x, camMaxXY.x);
                    spawnPoint.y = Random.Range(spawnAreaMinXY.y, camMinXY.y);
                    break;
                case 3:
                    spawnPoint.x = Random.Range(spawnAreaMinXY.x, camMinXY.x);
                    spawnPoint.y = Random.Range(camMinXY.y, spawnAreaMaxXY.y);
                    break;
                default:
                    Debug.LogError("Spawn Method Not Found");
                    spawnPoint = Vector2.zero;
                    break;
            }
            return spawnPoint;
        }

        private IEnumerator EnemySpawn()
        {
            yield return new WaitForSeconds(data.enemySpawnDelay);
            var enemy = Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity).GetComponent<EnemyManager>();
            enemy.transform.SetParent(_enemyParent.transform);
            enemy.target = target;
            enemy.enemyData = waveData[_currentWaveIndex].enemies[_currentEnemyIndex];
            enemy.gameObject.SetActive(true);
            Debug.Log("EnemySpawn : " + _currentEnemyIndex);
            if (waveData[_currentWaveIndex].enemies.Count- 1 <= _currentEnemyIndex)
            {
                StartCoroutine(NextWave());
                yield break;
            }
            _currentEnemyIndex++;
            StartCoroutine(EnemySpawn());
        }

        private IEnumerator NextWave()
        {
            if (waveData.Count -1 <= _currentWaveIndex)
            {
                Debug.Log("WaveEnd");
                yield break;
            }
            
            yield return new WaitForSeconds(data.waveDelay);
            
            _currentEnemyIndex = 0;
            _currentWaveIndex++;
            Debug.Log("Next Wave : "+ _currentWaveIndex);
            StartCoroutine(EnemySpawn());
        }

        private void OnDrawGizmos()
        {
            if (data == null) return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Camera.main.transform.position, data.spawnAreaSize);
        }
    }
}