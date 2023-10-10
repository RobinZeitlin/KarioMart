using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class S_CarCollisionManagement : MonoBehaviour
{

    //Script handles all types of collisions
    Rigidbody2D body;
    S_CarScript s_CarScript;

    [Header("Car Management")]
    [Range(1f, 10f)]
    [SerializeField]
    public float speedUpgrade;

    [Range(1f, 500f)]
    [SerializeField]
    public float knockBackForce;

    [Header("Audio Management")]
    [SerializeField]
    AudioSource AudioSourceCar;
    [SerializeField]
    AudioClip powerUp;

    [Header("Lap Management")]
    public TextMeshProUGUI myLapCountText;

    private int checkPointCount;

    public int lapCount;

    private void Awake()
    {
        lapCount = 0;
    }
    private void Start()
    {
        s_CarScript = GetComponent<S_CarScript>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (myLapCountText != null)
            myLapCountText.text = lapCount.ToString() + "/3";

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Knockback logic
        body.velocity = ((new Vector2(transform.position.x, transform.position.y) - collision.GetContact(0).point).normalized * (knockBackForce * 10) * Time.deltaTime);
        s_CarScript.enabled = false;
        s_CarScript.CarCrash();
        Cooldown();
    }

    public async void Cooldown()
    {
        //KnockBack for car
        await Task.Delay(300);
        s_CarScript.enabled = true;
        body.velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Powerup
        if (collision.transform.tag == "Speed")
        {
            s_CarScript.speed += speedUpgrade;
            AudioSourceCar.PlayOneShot(powerUp, 1);
            Destroy(collision.gameObject);
        }

        //Add checkpoint
        if (collision.transform.tag == "CheckPoint")
            checkPointCount = 1;

        //Goal
        if (collision.transform.tag == "Goal" && checkPointCount == 1)
        {
            lapCount += 1;
            checkPointCount = 0;


            if (lapCount >= 3)
            {
                S_SceneManager.Instance.PlayerWins = true;
                S_SceneManager.Instance.ChangeSceneIndex();
            }
        }
    }
}
