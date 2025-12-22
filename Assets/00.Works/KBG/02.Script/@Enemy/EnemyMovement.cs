using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace KBG.Script.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyManager _manager;
        public float currentSpeed;

        private void Awake()
        {
            _manager = GetComponent<EnemyManager>();
        }

        public void OnEnable()
        {
            currentSpeed = _manager.enemyData.MoveSpeed;
        }

        private void FixedUpdate()
        {
            _manager.rb.linearVelocity = (_manager.target.position - transform.position).normalized * currentSpeed;
        }
    }
}