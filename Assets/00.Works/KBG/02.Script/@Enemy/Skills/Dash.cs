using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace KBG.Script.Enemy.SKill
{
    [System.Serializable]
    public class Dash : IEnemySkill
    {
        [SerializeField] private float activeDistance;
        [SerializeField] private float stopDistance;
        [SerializeField] private float dashSpeed;
        private bool _isActive;
        public bool CheckRequirement(GameObject target, EnemyManager self)
        {
            if (_isActive) return false;
            return Vector2.Distance(target.transform.position, self.transform.position) <= activeDistance;
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            self.Movement.currentSpeed += dashSpeed;
            _isActive = true;
        }

        public void Cancel(EnemyManager self)
        {
            self.Movement.OnEnable();
        }

        public void OnStart(GameObject target, EnemyManager self)
        {
            _isActive = false;
        }

        public void OnUpdate(GameObject target, EnemyManager self)
        {
            if (Vector2.Distance(target.transform.position, self.transform.position) <= stopDistance)
                Cancel(self);
        }

        public void OnExit(GameObject target, EnemyManager self)
        {
        }
    }
}
