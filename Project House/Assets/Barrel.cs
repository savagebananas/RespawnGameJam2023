using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] public GameObject barel;
    [SerializeField] public float speed = 10f;
    private Rigidbody2D rb;
    [SerializeField] private bool hasMoved;
    [SerializeField] Wolf wolf;

    bool isMovingUp;
    bool isMovingDown;
    bool isMovingLeft;
    bool isMovingRight;


    // Update is called once per frame
    void Update()
    {
        if(hasMoved == false)
        {
            if(Input.GetKeyDown(KeyCode.W))// do set up
            {
                rb.velocity = new Vector2(0,speed);

                hasMoved = true;
                isMovingUp = true;

                transform.Rotate(new Vector3(0, 0, 90 *Time.deltaTime));
            }
            if(Input.GetKeyDown(KeyCode.A))// de set left
            {
                rb.velocity = new Vector2(-speed,0);
                hasMoved = true;
                isMovingLeft = true;

                transform.Rotate(new Vector3(0, 0, 90 *Time.deltaTime));
            }
            if(Input.GetKeyDown(KeyCode.D))// do set right
            {
                rb.velocity = new Vector2(speed,0);
                hasMoved = true;
                isMovingRight = true;

                transform.Rotate(new Vector3(0, 0, 90 *Time.deltaTime));
            }
            if(Input.GetKeyDown(KeyCode.S))// do set down
            {
                rb.velocity = new Vector2(0,-speed);
                hasMoved = true;
                isMovingDown = true;

                transform.Rotate(new Vector3(0, 0, 90 *Time.deltaTime));
            }
        }


    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        hasMoved = false;
        isMovingUp = false;
        isMovingDown = false;
        isMovingLeft = false;
        isMovingRight = false;
    }

    void OnCollisionEnter2D(Collision2D collision){
        //if colides with player stun player
        if(collision.transform.tag.Equals("builder") == true)
        {
            //Builder.stun
        }

        //if colides with monster stun monster
        if(collision.transform.tag.Equals("Enemy") == true)
        {
            wolf.Stun();
        }

        Destroy(barel);

    }

    
}
