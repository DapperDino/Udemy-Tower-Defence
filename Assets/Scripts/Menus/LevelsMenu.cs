using UnityEngine;
using UnityEngine.SceneManagement;

namespace DapperDino.TD.Menus
{
    public class LevelsMenu : MonoBehaviour
    {
        public void GoToLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
