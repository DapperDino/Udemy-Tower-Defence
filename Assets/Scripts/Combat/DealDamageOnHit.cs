using DapperDino.TD.Enemies;
using UnityEngine;

namespace DapperDino.TD.Combat
{
    public class DealDamageOnHit : MonoBehaviour
    {
        [SerializeField] private int damage = 10;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Enemy>(out var enemy))
            {
                return;
            }

            enemy.DealDamage(damage);
        }
    }
}
