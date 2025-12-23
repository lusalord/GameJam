using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace KBG.Script.Enemy.SKill
{
    public class MissileProjectile : MonoBehaviour
    {
        public int damage;
        private Transform target;
        private Vector2 _startPos;
        private float _time;
        private float speed;
        private float launchDistance;
        private float impactDistance;
        
        private Vector2[] points = new Vector2[4];

        public void Initialize(int damage,Transform target, float speed,float launchDistance,float impactDistance)
        {
            this.damage = damage;
            this.target = target;
            this.speed = speed;
            this.launchDistance = launchDistance;
            this.impactDistance = impactDistance;
        }
        private void OnEnable()
        {
            _time = 0;
            _startPos = transform.position;
            SetPoints();
        }

        private void SetPoints()
        {
            points[0] = _startPos;
            points[1] = GetRandomPoint(_startPos, launchDistance);
            points[2] = GetRandomPoint(target.transform.position, impactDistance);
            points[3] = target.transform.position;
        }

        private Vector2 GetRandomPoint(Vector2 pos, float distance)
        {
            Vector2 p = new Vector2(distance*Mathf.Cos(Random.Range(0, 360) * Mathf.Deg2Rad) + pos.x,
                distance*Mathf.Sin(Random.Range(0, 360) * Mathf.Deg2Rad)+pos.y);
            return p;
        }
        
        private void Update()
        {
            if (_time >= 1) return;
            _time += Time.deltaTime * speed;
            Vector2 pos = new Vector2(
                FourPointBezier(points[0].x, points[1].x, points[2].x, points[3].x, _time),
                FourPointBezier(points[0].y, points[1].y, points[2].y, points[3].y, _time));
            transform.position = pos;
        }

        private float FourPointBezier(float a, float b, float c, float d, float t)
        {
            return Mathf.Pow((1 - t), 3) * a
                   + Mathf.Pow((1 - t), 2) * 3 * t * b
                   + Mathf.Pow(t, 2) * 3 * (1 - t) * c
                   + Mathf.Pow(t, 3) * d;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            foreach (var p in points)
            {
                Gizmos.DrawSphere(p, 0.1f);
            }
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(points[0], 0.1f);
                
        }
    }
}

