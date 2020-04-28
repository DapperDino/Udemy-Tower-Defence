using UnityEditor;
using UnityEngine;

namespace DapperDino.TD.Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
