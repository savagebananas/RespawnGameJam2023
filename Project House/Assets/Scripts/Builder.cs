using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField]Animator anim;
    private SpriteRenderer sprite;
    public float freezeTime = 3f;

    Vector3 lastPos;
    private float angle;
    private float timer = 0.1f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator> ();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("side", false);
        anim.SetBool("idle", false);
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x - lastPos.x;
        var y = transform.position.y - lastPos.y;
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        //Up
        if (angle >= 45 && angle <= 135)
        {
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("side", false);
            anim.SetBool("idle", false);
        }
        //Down
        if (angle >= -135 && angle <= -45)
        {
            anim.SetBool("up", false);
            anim.SetBool("down", true);
            anim.SetBool("side", true);
            anim.SetBool("idle", false);
        }

        //Left
        if (angle >= 135 && angle <= 180 || angle > -180 && angle <= -135)
        {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            anim.SetBool("idle", false);
            sprite.flipX = true;
        }
        //Right
        if (angle <= 45 && angle >= 0 || angle <= 0 && angle >= -45)
        {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            anim.SetBool("idle", false);
            sprite.flipX = false;
        }

        //StartCoroutine(setlastPos());
        if (timer <= 0)
        {
            lastPos = transform.position;
            timer = 0.5f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        //var directionVector = transform.position - lastPos;

    }

    IEnumerator setlastPos()
    {
        yield return new WaitForSeconds(0.04f);
        lastPos = transform.position;

    }
    private void resetAnimatorBools()
    {
        anim.SetBool("side", false);
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("idle", false);
    }

    private bool charMovedUp()
    {
        var dispacement = transform.position.y - lastPos.y;
        return dispacement > 0.01;
    }

    private bool charMovedDown()
    {
        var dispacement = transform.position.y - lastPos.y;
        return dispacement < 0.01;
    }

    private bool charMovedLeft()
    {
        var dispacement = transform.position.x - lastPos.x;
        return dispacement < 0.01;
    }

    private bool charMovedRight()
    {
        var dispacement = transform.position.x - lastPos.x;
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

    public void Die()
    {
        //Show death animation
        //play some sound
        //change scene to death screen
    }

}
