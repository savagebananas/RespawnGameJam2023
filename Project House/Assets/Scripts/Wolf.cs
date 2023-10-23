using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
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
        this.FreezePosition();
    }

    IEnumerator FreezePosition()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(freezeTime);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
