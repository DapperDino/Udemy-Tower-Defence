using UnityEngine;

namespace DapperDino.TD.Towers
{
    [CreateAssetMenu(fileName = "New Tower Data", menuName = "Towers/Tower Data")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private new string name = "New Tower Name";
        [SerializeField] private int price = 100;
        [SerializeField] private float dps = 10f;
        [SerializeField] private float range = 5f;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private TowerPreview previewPrefab = null;
        [SerializeField] private Tower towerPrefab = null;

        public string Name => name;
        public int Price => price;
        public float DPS => dps;
        public float Range => range;
        public Sprite Icon => icon;
        public TowerPreview PreviewPrefab => previewPrefab;
        public Tower TowerPrefab => towerPrefab;
    }
}
