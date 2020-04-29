using System;
using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData towerData = null;

        public static event Action<TowerHolder> OnTowerSelected;

        private TowerHolder towerHolder;

        public TowerData TowerData => towerData;

        public void Initialise(TowerHolder towerHolder)
        {
            this.towerHolder = towerHolder;
        }

        private void OnMouseDown() => OnTowerSelected?.Invoke(towerHolder);
    }
}
