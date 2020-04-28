using DapperDino.TD.Enemies;
using System;
using UnityEngine;

namespace DapperDino.TD.Waves
{
    [Serializable]
    public class Wave
    {
        [SerializeField] private Enemy[] enemies = new Enemy[0];

        public Enemy[] Enemies => enemies;
    }
}
