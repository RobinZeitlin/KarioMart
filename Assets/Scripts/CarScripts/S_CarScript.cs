using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_CarScript : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Car Management")]
    [Range(1f, 10f)]
    [SerializeField]
    public float speed;

    float acceleration;

    float storedTime;

    float buttonDown;

    float turningCar;

    public bool startEngine;

    [Header("Audio Sources")]
    [SerializeField]
    AudioSource CarAudioSource;
    [SerializeField]
    AudioSource CarAudioSource2;

    [Header("Audio Clip")]
    [SerializeField]
    AudioClip StartEngine;
    [SerializeField]
    AudioClip EngineRunning;
    [SerializeField]
    AudioClip CarCrashClip;

    // Start is called before the first frame update
    void Awake()
    {
        startEngine = false;
        rb = GetComponent<Rigidbody2D>();
        
    }
    public void FixedUpdate()
    {
        if (startEngine)
        {
            //Movement

            acceleration = Mathf.Clamp(acceleration, 0f, 5);

            if (buttonDown > 0)
                acceleration += speed / 2 * Time.deltaTime;
            else if (buttonDown <= 0)
                acceleration -= speed / 2 * Time.deltaTime;

            Vector3 force = (transform.up) * acceleration;

            rb.velocity = force;

            //Det här händer om spelaren rör sig
            if (rb.velocity.magnitude > 0.1f)
            {
                CarAudioSource2.volume = acceleration / 5;
                transform.eulerAngles -= new Vector3(0, 0, turningCar * speed);
            }
            
            if(!CarAudioSource2.isPlaying)
            CarAudioSource2.PlayOneShot(EngineRunning);
        }
    }

    public void CarCrash()
    {
        CarAudioSource2.Stop();
        CarAudioSource2.PlayOneShot(CarCrashClip, 1);
        startEngine = false;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        buttonDown = context.ReadValue<float>();
    }

    public void OnStartEngine(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.velocity = Vector2.zero;
            CarAudioSource.PlayOneShot(StartEngine, 1);
            StartMotor();
        }
    }

    public async void StartMotor()
    {
        await Task.Delay(2000);
        startEngine = !startEngine;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        turningCar = context.ReadValue<float>();
    }
}
