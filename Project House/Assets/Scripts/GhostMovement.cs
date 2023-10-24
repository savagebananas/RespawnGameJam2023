using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector3[] movePositions;
    private int index;
    private int ind;
    private Vector2 vel;
    private float velocity = 0.4f;
    void Start()
    {
        movePositions = SpawnGhost.positions[index];
        rb = GetComponent<Rigidbody2D>();
        ind = 1;
        vel = ((Vector2) movePositions[ind] - (Vector2) movePositions[0])*velocity;
        rb.velocity = vel;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position==movePositions[ind]) {
            ind = 2/ind;
            transform.Rotate(new Vector3(0, 0, 180));
            vel.x *= -1;
        }
        rb.velocity = vel;
    }
    public void setIndex(int i) {
        index = i;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        ind = 2/ind;
        vel.x *= -1;

    }
}
