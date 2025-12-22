using UnityEngine;

namespace KBG.Script.Manager.SO
{
    [CreateAssetMenu(menuName = "SO/Data/SpawnData")]
    public class SpawnData :  ScriptableObject
    {
        public float enemySpawnDelay;
        public float waveDelay;
        public Vector2 spawnAreaSize;
    }
}