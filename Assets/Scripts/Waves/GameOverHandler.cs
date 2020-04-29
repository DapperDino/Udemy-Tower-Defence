using UnityEngine;
using UnityEngine.SceneManagement;

namespace DapperDino.TD.Waves
{
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private GameObject playerWinPanel = null;
        [SerializeField] private GameObject playerLosePanel = null;

        private int nextLevelIndex;

        public const string HighestLevelIndex = "HighestLevelIndex";

        private void OnEnable()
        {
            WaveHandler.OnPlayerWin += HandlePlayerWin;
        }

        private void OnDisable()
        {
            WaveHandler.OnPlayerWin -= HandlePlayerWin;
        }

        private void HandlePlayerWin()
        {
            playerWinPanel.SetActive(true);

            string activeSceneName = SceneManager.GetActiveScene().name;
            string levelIndex = activeSceneName.Split('_')[2];
            int levelIndexValue = int.Parse(levelIndex);
            if(PlayerPrefs.GetInt(HighestLevelIndex, 1) < levelIndexValue)
            {
                PlayerPrefs.SetInt(HighestLevelIndex, levelIndexValue);
            }
            nextLevelIndex = levelIndexValue + 1;
        }

        public void GoToNext()
        {
            if (Application.CanStreamedLevelBeLoaded($"Scene_Level_{nextLevelIndex}"))
            {
                SceneManager.LoadScene($"Scene_Level_{nextLevelIndex}");
            }
            else
            {
                SceneManager.LoadScene("Scene_Menu");
            }
        }
    }
}
