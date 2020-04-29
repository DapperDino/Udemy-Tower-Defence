using TMPro;
using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TowerShop towerShop = null;
        [SerializeField] private TMP_Text moneyText = null;

        private void OnEnable()
        {
            HandleMoneyChanged(towerShop.Money);

            towerShop.OnMoneyChanged += HandleMoneyChanged;
        }

        private void OnDisable()
        {
            towerShop.OnMoneyChanged -= HandleMoneyChanged;
        }

        private void HandleMoneyChanged(int money)
        {
            moneyText.text = $"${money}";
        }
    }
}
