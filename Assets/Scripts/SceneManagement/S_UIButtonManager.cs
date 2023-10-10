using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class S_UIButtonManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PauseMenu;

    PlayerInput input;
    bool paused;

    private void Start()
    {
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        PauseMenu.SetActive(false);
        paused = false;
        input.actions.FindAction("Pause").started += Pause;
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            paused = !paused;
            PauseMenu.SetActive(paused);

            if (paused)
                Time.timeScale = 0;
            else if (!paused)
                Time.timeScale = 1;
        }
    }

    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene(SceneUtility.GetScenePathByBuildIndex(index));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        LoadScene("Level1");
    }

    public void LoadScene(string sceneToLoad)
    {
        print(sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
