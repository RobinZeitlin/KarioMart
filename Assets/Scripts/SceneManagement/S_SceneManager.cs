using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    public int currentSceneIndex;
    public bool PlayerWins;
    public S_scriptableScenes sceneChooser;
    public static S_SceneManager Instance;

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
        currentSceneIndex = 0;
        PlayerWins = false;
    }
    public void Update()
    {
        Win();
    }

    public void Win()
    {
        print(sceneChooser.sceneList.Count);
        print(currentSceneIndex);

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



