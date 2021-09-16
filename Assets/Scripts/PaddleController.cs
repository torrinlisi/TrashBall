using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PaddleController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0)
            {
                // move left
                rb.velocity = Vector2.left * moveSpeed;
            }
            else
            {
                // move right
                rb.velocity = Vector2.right * moveSpeed;
            }
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }
}
