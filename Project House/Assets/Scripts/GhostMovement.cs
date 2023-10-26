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
    public static float dist = 5;

    private SpriteRenderer sprite;
    private Animator animator;
    void Start()
    {
        timeOffset = Time.time;
        
        updatePositions();
        rb = GetComponent<Rigidbody2D>();
        ind = 1;
        vel = ((Vector2) movePositions[ind] - (Vector2) movePositions[0])*velocity;
        rb.velocity = vel;

        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        updateSpriteFlip();
        if (transform.position==movePositions[ind]) {
            ind = 2/ind;
            if (gameObject.tag.Equals("horizontal")) vel.x *= -1;
            if (gameObject.tag.Equals("vertical")) vel.y *= -1;
        }
        rb.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == 5) return;
        if (coll.gameObject.layer == 2) return;
        if (coll.gameObject.tag.Equals("phone")) return;
        if (coll.gameObject.tag.Equals("builder")) {
            coll.gameObject.GetComponent<Builder>().Die();
            return;
        }
        ind = 2/ind;
        if (gameObject.tag.Equals("horizontal")) vel.x *= -1;
        if (gameObject.tag.Equals("vertical")) vel.y *= -1;
    }
    public void updatePositions() {
        movePositions[0] = transform.position;
        if (gameObject.tag.Equals("horizontal")) {
            movePositions[1] = transform.position+new Vector3(dist, 0, 0);
            movePositions[2] = transform.position-new Vector3(dist, 0, 0);
        }  else if (gameObject.tag.Equals("vertical")) {
            movePositions[1] = transform.position+new Vector3(0, dist, 0);
            movePositions[2] = transform.position-new Vector3(0, dist, 0);
        }
    }

    private void updateSpriteFlip()
    {
        if (rb.velocity.x > 0||rb.velocity.y>0) sprite.flipX = true;
        else sprite.flipX = false;
    }


}
