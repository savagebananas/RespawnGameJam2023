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
    public GameObject wolfFire;

    public float freezeTime = 3f;
    private float freezeTimer = 3f;
    public float attackTime = 3f;
    private float attackTimer = 3f;
    private bool isAttacking = false;
    private bool isIdle = false;

    private Collider2D breakable;
    private float flipXtimer = 0.1f;
    private float angle;
    private bool shouldBreak;
    private bool isBreaking = false;


    private bool builderAlive = true;

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

        if(isBreaking == false)
        {
        FindObjectOfType<AudioManager>().Stop("WolfSwipe");
        }
        
        

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
        
       FindObjectOfType<AudioManager>().Play("WolfHurt"); 
       StartCoroutine(fireFright());
        
    }

    IEnumerator fireFright()
    {
        GetComponent<AIPath>().speed = 4f;
        Debug.Log("Hit hit hit hit hit hti hit");
        wolfFire.SetActive(true);
        GetComponent<AIDestinationSetter>().enabled = false;
        Vector3 thePointToFleeFrom = Vector3.zero;
        int theGScoreToStopAt = 10000;
        FleePath path = FleePath.Construct (transform.position, thePointToFleeFrom, theGScoreToStopAt);
        path.aimStrength = 1;
        path.spread = 4000;
        Seeker seeker = GetComponent<Seeker>();
        seeker.StartPath(path);

        yield return new WaitForSeconds(freezeTime * 3);
        GetComponent<AIDestinationSetter>().enabled = true;
        wolfFire.SetActive(false);
        GetComponent<AIPath>().speed = 1.51f;
        //GetComponent<AIDestinationSetter>().target = builder.transform;
    }

    void OnCollisionStay2D(Collision2D collision){
        //if colides with player stun player
        if(collision.gameObject.tag.Equals("builder") == true && builderAlive)
        {
            isAttacking = true;
            StartCoroutine(builderDeath());
            builderAlive = false;
        }

        if(collision.gameObject.tag.Equals("breakable") == true)
        {
            FindObjectOfType<AudioManager>().Play("WolfSwipe");
            if (!isIdle) isAttacking = true;
            collision.gameObject.GetComponent<DraggableFurniture>().isBreaking = true;
            breakable = collision.collider;
            //bool shouldBreak = false;
            if (!isBreaking) StartCoroutine(WolfBreak(collision));

            // RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, builder.transform.position-transform.position);
            // foreach (RaycastHit2D hit in hits) {
            //     if (hit.collider==collision.collider) {
            //         shouldBreak = true;
            //         break;
            //     }
            // }
            
            // if (!shouldBreak) {
            //     float angle = Vector3.Angle(collision.gameObject.transform.position-transform.position, builder.transform.position-transform.position);
            //     if (angle<110) {
            //         shouldBreak = true;
            //     }
            //}
            //if (!shouldBreak) StartCoroutine(stopBreaking(collision));

        }
    }
    
    IEnumerator stopBreaking(Collision2D collision) {
        GetComponent<AIDestinationSetter>().target = builder.transform;
        collision.gameObject.layer = 6;
        collision.gameObject.GetComponent<DraggableFurniture>().isBreaking = false;
        AstarPath.active.Scan();
        isAttacking = false;
        isBreaking = false;
        yield return new WaitForSeconds(1f);
        collision.gameObject.layer = 0;
    }


    IEnumerator builderDeath()
    {
        yield return new WaitForSeconds(0.2f);
        builder.Die();
        isIdle = true;
        isAttacking = false;
        Destroy(this);
    }

    IEnumerator WolfBreak(Collision2D collision)
    {
        isBreaking = true;
        //stop movement
        GetComponent<AIDestinationSetter>().target = rb.transform;
        isAttacking = true;
        yield return new WaitForSeconds(2.5f); 

        if (collision.gameObject.tag.Equals("breakable")&&isBreaking) Destroy(collision.gameObject);

        //continue movement
        GetComponent<AIDestinationSetter>().target = builder.transform;

        isAttacking = false;
        isBreaking = false;
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
                if (breakable != null && breakable.tag.Equals("breakable")) Destroy(breakable.gameObject);
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
