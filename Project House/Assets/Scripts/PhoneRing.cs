using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PhoneRing : MonoBehaviour
{

    [SerializeField] GameObject phone;
    [SerializeField] GameObject connectedTask;
    [SerializeField] GameObject builder;

    // Start is called before the first frame update
    void Start()
    {
        //phone.enabled = false;
        phone.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onEnble()
    {
        phone.GetComponent<CircleCollider2D>().enabled = true;
    }

    void OnMouseDown()
    {
        this.enabled = true;
        StartCoroutine(Ring());
    }

    IEnumerator Ring()
    {
        //play sound
        //start animation

        yield return new WaitForSeconds(1f);
        //Stop sound
        //stop animation

        this.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision .transform.tag.Equals("builder") == true)
        {
            builder.GetComponent<AIDestinationSetter>().target = this.connectedTask.transform;
        }
    }
}
