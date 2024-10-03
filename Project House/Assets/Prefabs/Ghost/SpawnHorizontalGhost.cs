using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHorizontalGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    private int length = 3;
    GameObject obj;
    private int numGhosts = 6;
    private int numLocations = 18;
    //public GameObject pointer;
    //GameObject pnt;
    private static string baseName = "GhostLocation";
    public List<Transform> locations;

    void Start()
    {
        
        int locationsPerGhost = (numLocations)/numGhosts;
        if (locations == null) {
            foreach (Transform child in transform) {
                locations.Add(child);
            }
        }
        GhostMovement.setLocations(locations);
        //for (int j = 0; j<numGhosts; j++) {
            //for (int i = 0; i<locationsPerGhost;i++) {
                //string name = baseName;
                //int num = (1+locationsPerGhost*(j)+i);
                //name =name + num;
                //locations.Add(GameObject.Find(name).transform);
                //Debug.Log(name);
            //}
            Debug.Log("Ghost Spawn");
            for (int i = 0; i<numGhosts; i++) {
                obj = Instantiate(ghost, locations[i*numGhosts].position, Quaternion.identity); 
                locations[i*numGhosts].gameObject.GetComponent<GhostLocationRadius>().setShouldSpawn(false); 
            }
        
            //pnt = Instantiate(pointer);
            //pnt.GetComponent<Pointer>().setTarget(obj);
  
    }

}
