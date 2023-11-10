using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollision : MonoBehaviour
{
    public GameObject particles;
    void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Stop("BarrelRoll");
        //if colides with player stun player
        if (collision.transform.tag.Equals("builder") == true)
        {
            collision.transform.GetComponent<Builder>().Die();
        }

        //if colides with monster stun monster
        if (collision.transform.tag.Equals("Enemy") == true)
        {
            collision.gameObject.GetComponent<Wolf>().Stun();
        }

        GameObject o = Instantiate(particles, this.transform);
        o.transform.parent = null;
        FindObjectOfType<AudioManager>().Play("BarrelBreak");
        Destroy(this.transform.parent.gameObject);
        
    }
}
