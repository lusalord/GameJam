using UnityEngine;

namespace KBG.Script.Enemy.SKill
{
    public interface IEnemySkill
    {
        public bool CheckRequirement();
        public void OnSkill(GameObject target, EnemyManager self);

        public void OnStart(GameObject target, EnemyManager self);
        public void OnUpdate(GameObject target, EnemyManager self);
        public void OnExit(GameObject target, EnemyManager self);
    }   
} 
