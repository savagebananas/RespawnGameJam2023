using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

   [SerializeField] Rigidbody2D rb;
    [SerializeField]Animator anim;
    Vector3 lastPos;
    public float freezeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator> ();

        anim.SetBool("upLeft", false);
        anim.SetBool("upRight", false);
        anim.SetBool("upUp", false);
        anim.SetBool("downLeft", false);
        anim.SetBool("downRight", false);
        anim.SetBool("downDown", false);
        anim.SetBool("leftLeft", false);
        anim.SetBool("rightRight", false);
    }

    // Update is called once per frame
    void Update()
    {
        //up and left
        if(charMovedUp() && charMovedLeft())
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
           else  if(charMovedUp() && charMovedRight())
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
           else if(charMovedUp())
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
          else  if(charMovedDown() && charMovedLeft())
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
           else if(charMovedDown() && charMovedRight())
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
           else if(charMovedDown())
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
          else  if(charMovedLeft())
        {
            anim.SetBool("upLeft", false);
            anim.SetBool("upRight", false);
            anim.SetBool("upUp", false);
            anim.SetBool("downLeft", false);
            anim.SetBool("downRight", false);
            anim.SetBool("downDown", false);
            anim.SetBool("leftLeft", true);
            anim.SetBool("rightRight", false);
        }

        //right
          else  if(charMovedRight())
        {
            anim.SetBool("upLeft", false);
            anim.SetBool("upRight", false);
            anim.SetBool("upUp", false);
            anim.SetBool("downLeft", false);
            anim.SetBool("downRight", false);
            anim.SetBool("downDown", false);
            anim.SetBool("leftLeft", false);
            anim.SetBool("rightRight", true);
        }
    }

    private bool charMovedUp()
    {
        var dispacement = transform.position.y - lastPos.y;
        lastPos = transform.position;
        return dispacement > 0.01;
    }

    private bool charMovedDown()
    {
        var dispacement = transform.position.y - lastPos.y;
        lastPos = transform.position;
        return dispacement < 0.01;
    }

    private bool charMovedLeft()
    {
        var dispacement = transform.position.x - lastPos.x;
        lastPos = transform.position;
        return dispacement < 0.01;
    }

    private bool charMovedRight()
    {
        var dispacement = transform.position.x - lastPos.x;
        lastPos = transform.position;
        return dispacement > 0.01;
    }

    public void Stun()
    {
        this.FreezePosition();
    }

    IEnumerator FreezePosition()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(freezeTime);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

}
