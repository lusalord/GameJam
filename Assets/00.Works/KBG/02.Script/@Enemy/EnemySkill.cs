using System;
using KBG.Script.Enemy.SKill;
using UnityEngine;

namespace KBG.Script.Enemy
{
    public class EnemySkill : MonoBehaviour
    {
        private EnemyManager _manager;
        private EnemyDataSO _data;
        private IEnemySkill _skill;

        private void Awake()
        {
            _manager = GetComponent<EnemyManager>();
        }

        private void OnEnable()
        {
            _data = _manager.enemyData;
            _skill = _data.Skill;
            _skill?.OnStart(_manager.target.gameObject, gameObject);
        }

        private void Update()
        {
            if (_skill == null) return;
            _skill.OnUpdate(_manager.target.gameObject, gameObject);
            if (_skill.CheckRequirement(_data.SkillRequirement))
                _skill.OnSkill(_manager.target.gameObject, gameObject);
        }

        private void OnDisable()
        {
            _skill?.OnExit(_manager.target.gameObject, gameObject);
        }
    }
}
