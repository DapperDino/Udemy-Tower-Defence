using UnityEngine;

namespace DapperDino.TD.Enemies
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private Node[] nodes = new Node[0];

        private int nextNodeIndex;

        public Node NextNode
        {
            get
            {
                if (nodes.Length == 0) { return null; }

                Node nextNode = nodes[nextNodeIndex];

                if (nextNodeIndex + 1 != nodes.Length)
                {
                    nextNodeIndex++;
                }
                else
                {
                    nextNodeIndex = 0;
                }

                return nextNode;
            }
        }

        #region Debug

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            Vector3 myPos = transform.position + new Vector3(0f, 0.5f, 0f);

            Gizmos.DrawWireSphere(myPos, 0.5f);

            foreach (var node in nodes)
            {
                Gizmos.DrawLine(myPos, node.transform.position + new Vector3(0f, 0.5f, 0f));
            }
        }

        #endregion
    }
}
