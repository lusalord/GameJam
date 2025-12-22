using System;
using UnityEngine;

namespace KBG.Script.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyManager _manager;

        private void Awake()
        {
            _manager = GetComponent<EnemyManager>();
        }

        private void FixedUpdate()
        {
            _manager.rb.linearVelocity = (_manager.target.position - transform.position).normalized * _manager.enemyData.MoveSpeed;
        }
    }
}