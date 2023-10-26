using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    
    [SerializeField] private bool hasMoved;

    public bool isMovingUp = false;
    public bool isMovingDown = false;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    public GameObject barrelRight;
    public GameObject barrelUp;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("BarrelRoll");
    }

    void Update()
    {
        if(hasMoved == false)
        {
            if(isMovingUp)
            {
                rb.velocity = new Vector2(0,speed);
                transform.GetChild(0).gameObject.SetActive(true);
                hasMoved = true;
            }
            if(isMovingLeft)
            {
                rb.velocity = new Vector2(-speed,0);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                hasMoved = true;
            }
            if(isMovingRight)
            {
                rb.velocity = new Vector2(speed,0);
                transform.GetChild(1).gameObject.SetActive(true);
                hasMoved = true;
            }
            if(isMovingDown)
            {
                rb.velocity = new Vector2(0,-speed);
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                hasMoved = true;
            }
        }
    }
}
