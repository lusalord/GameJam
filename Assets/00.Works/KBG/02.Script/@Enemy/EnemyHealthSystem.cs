using System;
using KBG.Script.Enemy;
namespace UnityEngine
{
    public class EnemyHealthSystem : MonoBehaviour
    {
        public int Hp {get; private set;}
        private EnemyManager _manager;
        public EnemyDataSO Data { get; private set; }

        private void Awake()
        {
            _manager = GetComponent<EnemyManager>();
        }

        private void OnEnable()
        {
            Data = _manager.enemyData;
            Hp = Data.MaxHp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage">Damage Amount</param>
        /// <returns>whether it is dead</returns>
        public bool TakeDamage(int damage)
        {
            Hp -= damage;
            return Hp <= 0;
        }
    }
}
