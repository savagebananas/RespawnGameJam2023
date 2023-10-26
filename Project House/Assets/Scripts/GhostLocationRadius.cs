using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLocationRadius : MonoBehaviour
{
    public bool shouldSpawn = true;
    private static string builder = "builder";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals(builder)) {
            shouldSpawn = false;
        }
       
    }
    public bool getShouldSpawn() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        bool x = hit.collider!=null&&!hit.collider.gameObject.tag.Equals("phone")&&hit.collider.gameObject.layer!=5;
        if (x) shouldSpawn = false;
        return shouldSpawn;
    }
}