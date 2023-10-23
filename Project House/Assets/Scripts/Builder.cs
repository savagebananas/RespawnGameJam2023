using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    Vector3 lastPos;
    public float freezeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();

        anim.SetBool("upLeft", false);
        anim.SetBool("upRight", false);
        anim.SetBool("upUp", false);
        anim.SetBool("downLeft", false);
        anim.SetBool("downRight", false);
        anim.SetBool("downDown", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(charMoved() == true)
        {
            //up and left
            if(rb.velocity.y > 0 && rb.velocity.x < 0)
            {
                anim.SetBool("upLeft", true);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", false);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);

            }

            //up and right
            else if(rb.velocity.y > 0 && rb.velocity.x > 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", true);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", false);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);
            }

            //just up
            else if(rb.velocity.y > 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", true);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", false);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);
            }

            //down and left
            else if(rb.velocity.y < 0 && rb.velocity.x < 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", true);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", false);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);
            }

            //down and right
            else if(rb.velocity.y < 0 && rb.velocity.x > 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", true);
                anim.SetBool("downDown", false);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);
            }

            //down
            else if(rb.velocity.y < 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", true);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", false);
            }

            //left
            else if(rb.velocity.x < 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", true);
                anim.SetBool("leftLeft", true);
                anim.SetBool("rightRight", false);
            }

            //right
            else if(rb.velocity.x > 0)
            {
                anim.SetBool("upLeft", false);
                anim.SetBool("upRight", false);
                anim.SetBool("upUp", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                anim.SetBool("downDown", true);
                anim.SetBool("leftLeft", false);
                anim.SetBool("rightRight", true);
            }
        }
    }

    private bool charMoved()
    {
        var dispacement = transform.position - lastPos;
        lastPos = transform.position;
        return dispacement.magnitude > 0.001;
    }

}
