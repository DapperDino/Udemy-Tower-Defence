using UnityEngine;

namespace DapperDino.TD.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemies/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int health = 50;
        [SerializeField] private int moneyReward = 20;
        [SerializeField] private float movementSpeed = 5f;

        public int Damage => damage;
        public int Health => health;
        public int MoneyReward => moneyReward;
        public float MovementSpeed => movementSpeed;
    }
}
