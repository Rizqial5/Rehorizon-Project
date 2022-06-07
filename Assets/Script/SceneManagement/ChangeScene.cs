using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rehorizon.SceneManagement
{
    public class ChangeScene : MonoBehaviour
    {
        public void MainGameScene()
        {
            SceneManager.LoadScene("MainGameplay");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
