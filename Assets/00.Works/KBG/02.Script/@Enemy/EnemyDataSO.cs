using KBG.Script.Enemy.SKill;
using UnityEngine;


namespace KBG.Script.Enemy
{
    [CreateAssetMenu(menuName = "SO/Enemy/Data")]
    public class EnemyDataSO : ScriptableObject
    {
        [field: SerializeField] public int MaxHp;
        [field: SerializeField] public float MoveSpeed { get; private set; }

        [SerializeReference, SubclassSelector(UseToStringAsLabel = true)] public IEnemySkill Skill;
    }
    
}