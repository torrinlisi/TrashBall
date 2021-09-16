using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce = 2;
    public bool startedBounce = false;
    private bool fasterCurrentDirection = false;

    public static BallController instance;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !startedBounce)
        {
            GameManagerController.instance.GameStart();
            StartBounce();
            startedBounce = true;
        }

        if(fasterCurrentDirection)
        {
            rb.AddForce(rb.velocity.normalized * bounceForce);
            fasterCurrentDirection = false;
        }
    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1, 1), 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    public void StopBounce()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "OutOfBounds")
        {
            GameManagerController.instance.ShowEndScreen();
        } else if(collision.gameObject.tag == "Paddle")
        {
            GameManagerController.instance.ScoreIncrement();
            Vector2 randomDirection = new Vector2(Random.Range(-5, 5), .5f);
            rb.AddForce(randomDirection, ForceMode2D.Impulse);

            if (rb.velocity.y < 1 || rb.velocity.x < 1)
                rb.AddForce(new Vector2(Random.Range(-5, 5), 1));
        } else if(collision.gameObject.tag == "Boundary")
        {
            fasterCurrentDirection = true;
        }
    }
}
