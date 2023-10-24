using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Wolf : MonoBehaviour
{
    [SerializeField] Builder builder;
    [SerializeField] GameObject wolf;
    Rigidbody2D rb;
    Animator anim;
    Vector3 lastPos;

    public float freezeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
         anim = transform.GetChild(0).GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(charMoved() == true)
        {
            anim.SetBool("isWalking", true);
        }
    }

    

    private bool charMoved()
    {
        var dispacement = transform.position - lastPos;
        lastPos = transform.position;
        return dispacement.magnitude > 0.001;
    }

    public void Stun()
    {
        StartCoroutine(FreezePosition());
    }

    IEnumerator FreezePosition()
    {
        this.GetComponent<AIDestinationSetter>().target = rb.transform;
        yield return new WaitForSeconds(freezeTime);
        this.GetComponent<AIDestinationSetter>().target = builder.transform;
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

    void OnCollisionEnter2D(Collision2D collision){
        //if colides with player stun player
        if(collision.transform.tag.Equals("builder") == true)
        {
            builder.Die();
        }

        if(collision .transform.tag.Equals("Barrier") == true)
        {
            StartCoroutine(WolfBreak(collision));
        }

    }

    IEnumerator WolfBreak(Collision2D collision)
    {
        //stop movement
        GetComponent<AIDestinationSetter>().target = rb.transform;

        //change animation

        //deal damage to object

        //timer for amount of time it takes to destroy
        yield return new WaitForSeconds(5.0f); 

        //stop animation

        //continue movement
        GetComponent<AIDestinationSetter>().target = rb.transform;
    }

    
}
