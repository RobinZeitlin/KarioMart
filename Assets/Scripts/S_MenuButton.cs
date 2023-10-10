using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MenuButton : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        S_UIButtonManager.LoadScene("Level1");
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        S_SceneManager.currentSceneIndex = level;
    }
}
