using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class TowerHolder : MonoBehaviour
    {
        public Tower Tower { get; private set; }

        public void SetTower(TowerData towerData)
        {
            Tower = Instantiate(towerData.TowerPrefab, transform);

            Tower.Initialise(this);
        }

        public void RemoveTower()
        {
            Destroy(Tower.gameObject);

            Tower = null;
        }
    }
}
