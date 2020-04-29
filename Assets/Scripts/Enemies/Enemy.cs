using System;
using UnityEngine;

namespace DapperDino.TD.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData = null;

        private Node targetNode;
        private Vector3 currentDirection;

        private int health;

        private const float MinDistance = 0.1f;

        public static event Action<EnemyData> OnKilled;

        public EnemyData EnemyData => enemyData;

        private void Start() => health = enemyData.Health;

        private void Update()
        {
            if (targetNode == null) { return; }

            MoveToTarget();
        }

        public void DealDamage(int damage)
        {
            health = Mathf.Max(health - damage, 0);

            if(health == 0)
            {
                OnKilled?.Invoke(enemyData);

                Destroy(gameObject);
            }
        }

        private void MoveToTarget()
        {
            transform.Translate(currentDirection * enemyData.MovementSpeed * Time.deltaTime, Space.World);

            if ((transform.position - targetNode.transform.position).sqrMagnitude < MinDistance * MinDistance)
            {
                SetNode(targetNode.NextNode);
            }
        }

        public void SetNode(Node nextNode)
        {
            targetNode = nextNode;

            if (targetNode == null) { return; }

            currentDirection = (targetNode.transform.position - transform.position).normalized;

            if(currentDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(currentDirection);
            }
        }
    }
}

