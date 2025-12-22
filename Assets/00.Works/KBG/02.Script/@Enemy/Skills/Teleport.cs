using UnityEngine;

namespace KBG.Script.Enemy.SKill
{
    [System.Serializable]
    public class Teleport : IEnemySkill
    {
        private float _range;
        private bool _isActive;
        public bool CheckRequirement(float skillRequirement)
        {
            _range = skillRequirement;
            return false;
        }

        public void OnSkill(GameObject target, GameObject self)
        {
            self.transform.position = target.transform.position + -(self.transform.position - target.transform.position);
            _isActive = true;
        }

        public void OnStart(GameObject target, GameObject self)
        {
            _isActive = false;
        }

        public void OnUpdate(GameObject target, GameObject self)
        {
            if (Vector2.Distance(self.transform.position, target.transform.position) < _range && !_isActive)
                OnSkill(target, self);
        }

        public void OnExit(GameObject target, GameObject self)
        {
        }
    }
}
