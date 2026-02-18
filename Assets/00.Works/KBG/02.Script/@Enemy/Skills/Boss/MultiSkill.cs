using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KBG.Script.Enemy.SKill
{
    [Serializable]
    public class MultiSkill : IEnemySkill
    {
        [SerializeField] [SerializeReference, SubclassSelector(UseToStringAsLabel =true)] private List<IEnemySkill> enemySkills;
        [SerializeField] private float skillCooldownMin;
        [SerializeField] private float skillCooldownMax;

        private float _lastSkillUsed;
        private float _currentCooldown;
        public bool CheckRequirement(GameObject target, EnemyManager self)
        {
            return (Time.time - _lastSkillUsed < _currentCooldown);
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            _currentCooldown = Random.Range(skillCooldownMin, skillCooldownMax);
            _lastSkillUsed = Time.time;

            foreach (var skill in enemySkills.Where(skill => skill.CheckRequirement(target, self)))
            {
                skill.OnSkill(target, self);
                return;
            }
        }

        public void OnStart(GameObject target, EnemyManager self)
        {
        }

        public void OnUpdate(GameObject target, EnemyManager self)
        {
        }

        public void OnExit(GameObject target, EnemyManager self)
        {
        }
    }
}