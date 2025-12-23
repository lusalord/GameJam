using System.Collections;
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
        public bool CheckRequirement(GameObject target, EnemyManager self)
        {
            return (Vector2.Distance(self.transform.position, target.transform.position) < range && !_isActive);
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            self.transform.position = target.transform.position + -(self.transform.position - target.transform.position);
            _isActive = true;
            self.StartCoroutine(SpeedDown(self));
        }

        private IEnumerator SpeedDown(EnemyManager self)
        {
            self.Movement.currentSpeed = 0;
            yield return new WaitForSeconds(waitTime);
            self.Movement.OnEnable();
        }

        public void OnStart(GameObject target, EnemyManager self)
        {
            _isActive = false;
        }

        public void OnUpdate(GameObject target, EnemyManager self)
        {
        }

        public void OnExit(GameObject target, EnemyManager self)
        {
        }
    }
}
