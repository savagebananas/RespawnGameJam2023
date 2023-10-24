using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moli : MonoBehaviour
{
    [SerializeField] public GameObject moli;
    [SerializeField] Wolf wolf;
    [SerializeField] float lifespan = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        StartCoroutine(Lifespan());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if colides with player stun player
        if(collision.transform.tag.Equals("builder") == true)
        {
            //Builder.stun
        }

        //if colides with monster stun monster
        if(collision.gameObject.CompareTag("Enemy"))
        {
            wolf.Burn();
        }
    }

    IEnumerator Lifespan()
    {
        
        yield return new WaitForSeconds(lifespan);
        if(moli != null)
        {
            GetComponent<Animator>().SetTrigger("Destroy");
        }
    }
}
