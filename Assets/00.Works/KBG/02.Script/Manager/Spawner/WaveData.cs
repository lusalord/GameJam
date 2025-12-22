using System.Collections.Generic;
using KBG.Script.Enemy;
using UnityEngine;

namespace KBG.Script.Manager.SO
{
    [CreateAssetMenu(menuName = "SO/Data/WaveData")]
    public class WaveData : ScriptableObject
    {
        public List<EnemyDataSO>  enemies;
    }
}
