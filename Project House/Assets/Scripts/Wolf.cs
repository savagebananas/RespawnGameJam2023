using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Wolf : MonoBehaviour
{
    [SerializeField] Builder builder;
    [SerializeField] GameObject wolf;
    public SpriteRenderer wolfRenderer;
    Rigidbody2D rb;
    Animator anim;
    Vector3 lastPos;
    CircleCollider2D colid;

    public float freezeTime = 3f;
    private float freezeTimer = 3f;
    public float attackTime = 3f;
    private float attackTimer = 3f;
    private bool isAttacking = false;
    private bool isIdle = false;

    private Collider2D breakable;
    private float flipXtimer = 0.1f;
    private float angle;

    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator> ();
        colid = GetComponent<CircleCollider2D>();

        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", false);
    }

    void Update()
    {
        setDirection();
        //wolfAttack();
        setAnimations();
        

        //Debug.Log("isIdle: " + isIdle + "   isAttacking: " + isAttacking);
    }


    private bool charMoved()
    {
        var dispacement = transform.position - lastPos;
        lastPos = transform.position;
        return dispacement.magnitude > 0.001;
    }

    public void Stun()
    {
        isIdle = true;
        isAttacking = false;
        StartCoroutine(FreezePosition());
    }

    IEnumerator FreezePosition()
    {
        this.GetComponent<AIDestinationSetter>().target = rb.transform;
        isIdle = true;

        yield return new WaitForSeconds(freezeTime);

        this.GetComponent<AIDestinationSetter>().target = builder.transform;
        isIdle = false;
    }

    public void Burn()
    {
        
       StartCoroutine(fireFright());
        
    }

    IEnumerator fireFright()
    {
        Debug.Log("Hit hit hit hit hit hti hit");
        GetComponent<AIDestinationSetter>().target = rb.transform;
        yield return new WaitForSeconds(freezeTime * 3);
        GetComponent<AIDestinationSetter>().target = rb.transform;
    }

    void OnCollisionStay2D(Collision2D collision){
        //if colides with player stun player
        if(collision.gameObject.tag.Equals("builder") == true)
        {
            builder.Die();
        }

        if(collision.gameObject.tag.Equals("obstacles") == true)
        {
            if (!isIdle) isAttacking = true;
            collision.gameObject.GetComponent<DraggableFurniture>().isBreaking = true;
            breakable = collision.collider;
            StartCoroutine(WolfBreak(collision));
        }
    }

    IEnumerator WolfBreak(Collision2D collision)
    {
        //stop movement
        GetComponent<AIDestinationSetter>().target = rb.transform;
        yield return new WaitForSeconds(5.0f); 

        Destroy(collision.gameObject);

        //continue movement
        GetComponent<AIDestinationSetter>().target = builder.transform;

        isAttacking = false;
    }

    public void wolfMove()
    {
        if (charMoved() == true && !isAttacking && !isIdle)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }
    }

    public void wolfAttack()
    {
        if (!isIdle && isAttacking)
        {
            if (attackTimer >= 0)
            {
                attackTimer -= Time.deltaTime;
                //stop movement
                GetComponent<AIDestinationSetter>().target = rb.transform;
            }
            else
            {
                if (breakable != null && breakable.tag.Equals("obstacle")) Destroy(breakable.gameObject);
                //continue movement
                GetComponent<AIDestinationSetter>().target = builder.transform;
                isAttacking = false;
            }
        }
    }

    public void wolfStun()
    {
        if (isIdle)
        {
            isAttacking = false;
            if (freezeTimer >= 0)
            {
                freezeTimer -= Time.deltaTime;
            }
            else
            {
                //continue movement
                GetComponent<AIDestinationSetter>().target = builder.transform;
                isIdle = false;
            }
        }
        freezeTimer = freezeTime;
    }

    private void setAnimations()
    {
        if (charMoved() == true && !isAttacking && !isIdle)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }
        if (isIdle)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
        }
        if (isAttacking)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isWalking", false);
        }
    }

    private void setDirection()
    {
        float x = transform.position.x - lastPos.x;
        
        if (x > 0)
        {
            wolfRenderer.flipX = true;
        }
        else if (x < 0)
        {
            wolfRenderer.flipX = false;
        }
    }
}
