using DapperDino.TD.Enemies;
using DapperDino.TD.Towers;
using System.Net.NetworkInformation;
using UnityEngine;

namespace DapperDino.TD.Combat
{
    public class ProjectileAttack : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Rigidbody projectilePrefab = null;
        [SerializeField] private float launchForce = 5f;

        private float timer;

        private TargetGetter targetGetter;

        private void Start() => targetGetter = GetComponent<TargetGetter>();

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer > 0f) { return; }

            timer = fireRate;

            Enemy target = targetGetter.Target;

            if (target == null) { return; }

            Rigidbody projectileInstance = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            projectileInstance.AddForce(spawnPoint.forward * launchForce, ForceMode.VelocityChange);
        }
    }
}
