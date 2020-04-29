using DapperDino.TD.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.TD.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Node startingNode = null;
        [SerializeField] private Wave[] waves = new Wave[0];

        private readonly Queue<Enemy> remainingSpawns = new Queue<Enemy>();

        private bool isSpawning;
        private float timeUntilNextSpawn;

        private Wave currentWave;

        private const float SpawnRate = 0.5f;

        public Enemy[] GetWave(int waveIndex) => waves[waveIndex].Enemies;

        private void Update()
        {
            if (!isSpawning) { return; }

            timeUntilNextSpawn -= Time.deltaTime;

            if (timeUntilNextSpawn <= 0f)
            {
                SpawnNextEnemy();
            }
        }

        public void StartWave(int waveIndex)
        {
            if (waveIndex >= waves.Length) { return; }

            currentWave = waves[waveIndex];

            foreach (var enemy in currentWave.Enemies)
            {
                remainingSpawns.Enqueue(enemy);
            }

            SpawnNextEnemy();

            isSpawning = true;
        }

        private void SpawnNextEnemy()
        {
            if (remainingSpawns.Count == 0) { return; }

            Enemy enemy = Instantiate(remainingSpawns.Dequeue(), transform.position, transform.rotation);

            enemy.SetNode(startingNode);

            if (remainingSpawns.Count == 0)
            {
                isSpawning = false;
                return;
            }

            timeUntilNextSpawn = SpawnRate;
        }
    }
}
