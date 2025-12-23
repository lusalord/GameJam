using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 4 + Random.Range(0f, 3f))
        {
            Instantiate(enemy);
            _timer = 0;
        }
    }

    
}
