using System;
using KBG.Script.Enemy;
namespace UnityEngine
{
    public class EnemyHealthSystem : MonoBehaviour
    {
        public int Hp;
        private EnemyManager _manager;

        private void Awake()
        {
            _manager = GetComponent<EnemyManager>();
        }

        private void OnEnable()
        {
            Hp = _manager.enemyData.MaxHp;
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
