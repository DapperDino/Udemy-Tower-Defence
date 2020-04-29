using DapperDino.TD.Enemies;
using System;
using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class TowerShop : MonoBehaviour
    {
        [SerializeField] private int money;
        [SerializeField] private Transform buttonHolder = null;
        [SerializeField] private TowerShopButton towerShopButton = null;
        [SerializeField] private TowerData[] towerDatas = new TowerData[0];

        public event Action<int> OnMoneyChanged;

        public int Money => money;

        private void OnEnable()
        {
            Enemy.OnKilled += HandleEnemyKilled;
        }

        private void Start()
        {
            foreach(var towerData in towerDatas)
            {
                TowerShopButton towerShopButtonInstance = Instantiate(towerShopButton, buttonHolder);

                towerShopButtonInstance.Initialise(towerData, this);
            }
        }

        private void OnDisable()
        {
            Enemy.OnKilled -= HandleEnemyKilled;
        }

        private void HandleEnemyKilled(EnemyData enemyData)
        {
            money += enemyData.MoneyReward;

            OnMoneyChanged?.Invoke(money);
        }

        public void SpendMoney(int amountToSpend)
        {
            money -= amountToSpend;

            OnMoneyChanged?.Invoke(money);
        }
    }
}
