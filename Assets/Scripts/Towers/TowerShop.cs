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

        private void Start()
        {
            foreach(var towerData in towerDatas)
            {
                TowerShopButton towerShopButtonInstance = Instantiate(towerShopButton, buttonHolder);

                towerShopButtonInstance.Initialise(towerData, this);
            }
        }
    }
}
