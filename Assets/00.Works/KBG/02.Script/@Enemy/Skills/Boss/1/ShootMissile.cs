using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KBG.Script.Enemy.SKill
{
    [Serializable]
    public class LaunchProjectile : IEnemySkill
    {
        [SerializeField] private float shootDistance;
        [Header("Projectile Settings")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int projectileDamage;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float projectileCount;
        [Header("Bezier")]
        [SerializeField] private float launchDistance;
        [SerializeField] private float impactDistance;
        public bool CheckRequirement(GameObject target, EnemyManager self)
        {
            return Vector2.Distance(target.transform.position, self.transform.position) >= shootDistance;
        }

        public void OnSkill(GameObject target, EnemyManager self)
        {
            for (int i = 0; i < projectileCount; i++)
            {
                var projectile = Object.Instantiate(projectilePrefab,  self.transform.position, Quaternion.identity).GetComponent<MissileProjectile>();
                projectile.Initialize(projectileDamage,target.transform, projectileSpeed, launchDistance, impactDistance);
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

