using UnityEngine;

namespace KBG.Script.Manager.SO
{
    [CreateAssetMenu(menuName = "SO/Data/SpawnData")]
    public class SpawnData :  ScriptableObject
    {
        public float enemySpawnDelayMin;
        public float enemySpawnDelayMax;
        public float waveDelay;
        public Vector2 spawnAreaSize;
    }
}