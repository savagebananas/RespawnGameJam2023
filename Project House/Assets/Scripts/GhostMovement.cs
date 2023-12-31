using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector3[] movePositions = new Vector3[3];
    private int ind = 1;
    private Vector2 vel;
    private float velocity = 0.4f;
    private float timeOffset = 0f;
    public static float x = 5;
    void Start()
    {
        timeOffset = Time.time;
        movePositions[0] = transform.position;
        movePositions[1] = transform.position+new Vector3(x,0,0);
        movePositions[2] = transform.position-new Vector3(x, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        ind = 1;
        vel = ((Vector2) movePositions[ind] - (Vector2) movePositions[0])*velocity;
        rb.velocity = vel;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Time.time-timeOffset-10)<0.05) {
            SpawnGhost.hasMoved = false;
        }
        if (transform.position==movePositions[ind]) {
            ind = 2/ind;
            transform.Rotate(new Vector3(0, 0, 180));
            vel.x *= -1;
        }
        rb.velocity = vel;
        
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == 5) return;
        if (coll.gameObject.tag.Equals("phone")) return;
        if (coll.gameObject.tag.Equals("builder")) {
            coll.gameObject.GetComponent<Builder>().Die();
            return;
        }
        ind = 2/ind;
        vel.x *= -1;
    }
    public void updatePositions() {
        movePositions[0] = transform.position;
        movePositions[1] = transform.position+new Vector3(x,0,0);
        movePositions[2] = transform.position-new Vector3(x, 0, 0);
    }


}
