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
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
        // the object identified by hit.transform was clicked
        // do whatever you want

        this.GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(Ring());
    }
  }
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
