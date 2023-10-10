using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_CarNames : MonoBehaviour
{
    [SerializeField]
    TMP_InputField MP_InputField;

    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    string nameOfPlayer;

    [SerializeField]
    public bool player1;

    public string sceneToLoad;
    public void ChangeName()
    {
        nameOfPlayer = MP_InputField.text;

        textMeshProUGUI.text = nameOfPlayer;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
