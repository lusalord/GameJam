using UnityEngine;

namespace KBG.Script.Enemy.SKill
{
    public interface IEnemySkill
    {
        public bool CheckRequirement(float requiredSkill);
        public void OnSkill(GameObject target, GameObject self);

        public void OnStart(GameObject target, GameObject self);
        public void OnUpdate(GameObject target, GameObject self);
        public void OnExit(GameObject target, GameObject self);
    }   
} 
