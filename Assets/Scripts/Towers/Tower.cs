using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData towerData = null;

        public TowerData TowerData => towerData;
    }
}
