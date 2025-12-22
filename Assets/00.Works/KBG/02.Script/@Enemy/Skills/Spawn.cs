using UnityEngine;

namespace KBG.Script.Enemy.SKill
{
    [System.Serializable]
    public class Spawn : IEnemySkill
    {
        [SerializeField] private GameObject spawnPrefab;
        [SerializeField] private EnemyDataSO spawnData;
        private GameObject _spawnedParent;
        public bool CheckRequirement()
        {
            return false;
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            var enemy = Object.Instantiate(spawnPrefab, self.transform.position, Quaternion.identity).GetComponent<EnemyManager>();
            enemy.transform.SetParent(_spawnedParent.transform);
            enemy.target = target.transform;
            enemy.enemyData = spawnData;
            enemy.gameObject.SetActive(true);
        }

        public void OnStart(GameObject target, EnemyManager self)
        {
            _spawnedParent = new GameObject("=======Spawn=======");
        }

        public void OnUpdate(GameObject target, EnemyManager self)
        {
        }

        public void OnExit(GameObject target, EnemyManager self)
        {
        }
    }
}

