using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_RaceManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] CanvasWithName;

    [Header("Player Handling")]
    [SerializeField]
    private PlayerInputManager playerInputManager;

    [SerializeField]
    List<GameObject> playerCars = new List<GameObject>();

    [SerializeField]
    List<Transform> SpawnPoints = new();

    [Header("Game Management")]

    [SerializeField]
    TextMeshProUGUI RaceStart;

    [SerializeField]
    AudioSource AudioSource;
    [SerializeField]
    AudioClip RaceBeep;
    [SerializeField]
    AudioClip Go;

    public List<TextMeshProUGUI> lapCounts = new List<TextMeshProUGUI>();

    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager.JoinPlayer(controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
        playerInputManager.JoinPlayer(controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);

        StartMatch();
    }

    public void PlayerJoined(PlayerInput input)
    {
        playerCars.Add(input.gameObject);
        input.gameObject.transform.position = SpawnPoints[playerCars.Count - 1].transform.position;
        input.gameObject.GetComponent<S_CarCollisionManagement>().myLapCountText = lapCounts[playerCars.Count - 1];
    }

    public async void StartMatch()
    {
        //CountDown
        for (int i = 3; i >= -1; i--)
        {
            if (i >= 0)
            {
                await Task.Delay(1000);
                RaceStart.text = i.ToString();
            }
            else
                RaceStart.text = "Go";
        }

        await Task.Delay(4000);
        if(RaceStart != null)
        RaceStart.gameObject.SetActive(false);
    }
}
