using DapperDino.TD.Enemies;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DapperDino.TD.Waves
{
    public class WaveHandler : MonoBehaviour
    {
        [SerializeField] private int numberOfWaves = 1;
        [SerializeField] private int secondsBetweenWaves = 10;
        [SerializeField] private TMP_Text secondsRemainingText = null;
        [SerializeField] private WaveSpawner[] waveSpawners = new WaveSpawner[0];

        private int currentWave;
        private float secondsUntilNextWave;

        private readonly Dictionary<EnemyData, int> enemiesToKill = new Dictionary<EnemyData, int>();

        private void OnEnable()
        {
            WaveDestination.OnEnemyReachedEnd += HandleEnemyKilled;
        }

        private void Start()
        {
            GetNextWave();
            ResetCountdown();
        }

        private void OnDisable()
        {
            WaveDestination.OnEnemyReachedEnd -= HandleEnemyKilled;
        }

        private void Update()
        {
            if (secondsUntilNextWave == 0f) { return; }

            secondsUntilNextWave -= Time.deltaTime;

            if (secondsUntilNextWave <= 0f)
            {
                secondsUntilNextWave = 0f;
                secondsRemainingText.enabled = false;

                StartNextWave();
            }

            secondsRemainingText.text = Mathf.Ceil(secondsUntilNextWave).ToString();
        }

        private void StartNextWave()
        {
            foreach (var spawner in waveSpawners)
            {
                spawner.StartWave(currentWave);
            }
        }

        private void HandleEnemyKilled(EnemyData enemyData)
        {
            if (enemiesToKill.ContainsKey(enemyData))
            {
                enemiesToKill[enemyData]--;

                if (enemiesToKill[enemyData] == 0)
                {
                    enemiesToKill.Remove(enemyData);
                }
            }

            if (enemiesToKill.Count == 0)
            {
                currentWave++;

                if (currentWave == numberOfWaves)
                {
                    //Player wins
                    return;
                }

                GetNextWave();

                ResetCountdown();
            }
        }

        private void ResetCountdown()
        {
            secondsUntilNextWave = secondsBetweenWaves;
            secondsRemainingText.enabled = true;
        }

        private void GetNextWave()
        {
            foreach (var spawner in waveSpawners)
            {
                foreach (var newEnemy in spawner.GetWave(currentWave))
                {
                    if (enemiesToKill.ContainsKey(newEnemy.EnemyData))
                    {
                        enemiesToKill[newEnemy.EnemyData]++;
                    }
                    else
                    {
                        enemiesToKill.Add(newEnemy.EnemyData, 1);
                    }
                }
            }
        }
    }
}
