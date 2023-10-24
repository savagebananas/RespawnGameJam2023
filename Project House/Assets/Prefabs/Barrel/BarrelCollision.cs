using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if colides with player stun player
        if (collision.transform.tag.Equals("builder") == true)
        {
            //Builder.stun
        }

        //if colides with monster stun monster
        if (collision.transform.tag.Equals("Enemy") == true)
        {
            collision.gameObject.GetComponent<Wolf>().Stun();
        }

        Destroy(this.transform.parent.gameObject);
    }
}
