using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector3[] movePositions;
    private int ind;
    private Vector2 vel;
    private float velocity = 0.4f;
    private float timeOffset = 0f;
    private int index = 0;
    void Start()
    {
        timeOffset = Time.time;
        movePositions = SpawnGhost.getVectors(0);
        rb = GetComponent<Rigidbody2D>();
        ind = 1;
        vel = ((Vector2) movePositions[ind] - (Vector2) movePositions[0])*velocity;
        rb.velocity = vel;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Time.time-timeOffset-10)<0.01) Destroy(this.gameObject);
        if (transform.position==movePositions[ind]) {
            ind = 2/ind;
            transform.Rotate(new Vector3(0, 0, 180));
            vel.x *= -1;
        }
        rb.velocity = vel;
        
    }

    void OnTriggerEnter2D(Collider2D coll) {
        ind = 2/ind;
        vel.x *= -1;
    }
    public void setIndex(int i) {
        index = i;
    }


}
