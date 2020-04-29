using DapperDino.TD.Waves;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DapperDino.TD.Menus
{
    public class LevelsMenu : MonoBehaviour
    {
        private Button[] levelButtons;

        private void Start()
        {
            levelButtons = GetComponentsInChildren<Button>();

            int highestLevelIndex = PlayerPrefs.GetInt(GameOverHandler.HighestLevelIndex, 0);

            for (int i = 0; i < highestLevelIndex + 1; i++)
            {
                levelButtons[i].interactable = true;
            }
        }

        public void GoToLevel(string levelName) => SceneManager.LoadScene(levelName);
    }
}
