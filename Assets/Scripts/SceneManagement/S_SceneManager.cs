using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    public static int currentSceneIndex;
    public bool PlayerWins;
    public S_scriptableScenes sceneChooser;
    public static S_SceneManager Instance;

    public SceneToStartWith sceneToLoad;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //Changes scene to the main menu based on enum
        SceneManager.LoadScene(((int)sceneToLoad));

        currentSceneIndex = 0;
        PlayerWins = false;
    }
    public void Update()
    {
        Win();
    }

    public void Win()
    {
        if (PlayerWins)
        {
            if (currentSceneIndex >= sceneChooser.sceneList.Count)
                currentSceneIndex = 0;

            SceneManager.LoadScene(sceneChooser.sceneList[currentSceneIndex]);

            PlayerWins = false;
        }
    }

    public void ChangeSceneIndex()
    {
        if (currentSceneIndex <= sceneChooser.sceneList.Count)
        {
            currentSceneIndex++;
        }
    }
}

public enum SceneToStartWith
{
    MainMenu = 0,
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
}



