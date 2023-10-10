using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class S_PersonScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite dead;

    bool alive;
    int movePoint;

    public List<Transform> movePoints = new List<Transform>();

    [Range(0.2f, 2)]
    [SerializeField]
    float speed;
    private void Awake()
    {
        alive = true;
        movePoint = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (alive)
        {
            if (Vector3.Distance(transform.position, movePoints[movePoint].position) < 0.1f)
                movePoint++;

                transform.position = Vector3.MoveTowards(transform.position, movePoints[movePoint].position, speed * Time.deltaTime);

            Vector3 from = transform.up;
            Vector3 to = movePoints[movePoint].position - transform.position;

            float angle = Vector3.SignedAngle(from, to, transform.forward);
            transform.Rotate(0.0f, 0.0f, angle);
        }

        if (movePoint == movePoints.Count - 1)
                movePoint = 0;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            spriteRenderer.sprite = dead;
            transform.GetComponent<CircleCollider2D>().enabled = false;
            alive = false;
        }
    }
}
