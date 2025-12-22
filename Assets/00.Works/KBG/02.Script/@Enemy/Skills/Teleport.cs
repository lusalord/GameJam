using UnityEngine;
using UnityEngine.Serialization;

namespace KBG.Script.Enemy.SKill
{
    [System.Serializable]
    public class Teleport : IEnemySkill
    {
        [SerializeField]private float range;
        [SerializeField]private float waitTime;
        private bool _isActive;
        private float _activeTime;
        public bool CheckRequirement()
        {
            return false;
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            self.transform.position = target.transform.position + -(self.transform.position - target.transform.position);
            _isActive = true;
            self.Movement.currentSpeed = 0;
            _activeTime = Time.time;
        }

        public void OnStart(GameObject target, EnemyManager self)
        {
            _isActive = false;
        }

        public void OnUpdate(GameObject target, EnemyManager self)
        {
            if (Vector2.Distance(self.transform.position, target.transform.position) < range && !_isActive)
                OnSkill(target, self);
            if (Time.time > waitTime + _activeTime && _isActive)
                self.Movement.currentSpeed = self.enemyData.MoveSpeed;
        }

        public void OnExit(GameObject target, EnemyManager self)
        {
        }
    }
}
