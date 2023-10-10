using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialization : MonoBehaviour
{
    //Initialization script
    [RuntimeInitializeOnLoadMethod]
    public static void SceneInitialization()
    {
        var sceneData = Resources.Load("SceneManagerPrefab");
        Instantiate(sceneData);
    }
}
