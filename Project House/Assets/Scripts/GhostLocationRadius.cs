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
        Debug.Log("Ghost Coll Enter");
        if (coll.gameObject.tag.Equals(builder)) {
            shouldSpawn = false;
        }
       
    }
    public bool getShouldSpawn() {
        return shouldSpawn;
    }
}