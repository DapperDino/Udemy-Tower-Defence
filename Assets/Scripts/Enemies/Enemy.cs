using UnityEngine;

namespace DapperDino.TD.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData = null;

        private Node targetNode;
        private Vector3 currentDirection;

        private const float MinDistance = 0.1f;

        public EnemyData EnemyData => enemyData;

        private void Update()
        {
            if (targetNode == null) { return; }

            MoveToTarget();
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

