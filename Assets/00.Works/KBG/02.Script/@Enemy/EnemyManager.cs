using System;
using UnityEngine;

namespace KBG.Script.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform target;
        public Rigidbody2D rb { get; private set; }
        public EnemyMovement Movement { get; private set; }
        [field:SerializeField] public EnemyDataSO enemyData;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            Movement = GetComponent<EnemyMovement>();
        }
    }
}
