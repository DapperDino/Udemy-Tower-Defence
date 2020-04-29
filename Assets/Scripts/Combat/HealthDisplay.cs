using TMPro;
using UnityEngine;

namespace DapperDino.TD.Combat
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem = null;
        [SerializeField] private TMP_Text healthText = null;

        private void OnEnable()
        {
            HandleHealthChanged(healthSystem.Health);

            healthSystem.OnHealthChanged += HandleHealthChanged;
        }

        private void OnDisable()
        {
            healthSystem.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(int health)
        {
            healthText.text = health.ToString();
        }
    }
}
