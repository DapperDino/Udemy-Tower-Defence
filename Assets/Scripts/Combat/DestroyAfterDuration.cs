using UnityEngine;

namespace DapperDino.TD.Combat
{
    public class DestroyAfterDuration : MonoBehaviour
    {
        [SerializeField] private float duration = 10f;

        private void Start() => Destroy(gameObject, duration);
    }
}
