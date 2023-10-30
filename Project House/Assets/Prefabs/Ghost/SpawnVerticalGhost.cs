using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVerticalGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    private int length = 3;
    GameObject obj;
    private int numGhosts = 3;
    private int numLocations = 9;
    //public GameObject pointer;
    //GameObject pnt;
    private static string baseName = "GL";
    private static string tag = "vertical";

    void Start()
    {
        int locationsPerGhost = numLocations/numGhosts;
        for (int j = 0; j<numGhosts; j++) {
            List<Transform> locations = new List<Transform>();
            for (int i = 0; i<locationsPerGhost;i++) {
                string name = baseName;
                int num = (1+locationsPerGhost*j+i);
                name = name + num;
                locations.Add(GameObject.Find(name).transform);
                Debug.Log(name);
            }
            Debug.Log("Ghost Spawn");
            obj = Instantiate(ghost, locations[0].position, Quaternion.identity);  
            obj.GetComponent<GhostMovement>().setLocations(locations);
            obj.tag = tag;
        }
            //pnt = Instantiate(pointer);
            //pnt.GetComponent<Pointer>().setTarget(obj);
  
    }
}
