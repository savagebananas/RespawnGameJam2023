using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    private int length = 3;
    GameObject obj;
    private int numGhosts = 6;
    private int numLocations = 9;
    //public GameObject pointer;
    //GameObject pnt;
    void Start()
    {
        int locationsPerGhost = (numLocations*2)/numGhosts;
        for (int j = 0; j<numGhosts; j++) {
            string tag;
            if (j%2==0) tag = "horizontal";
            else tag = "vertical";
            List<Transform> locations = new List<Transform>();
            for (int i = 0; i<locationsPerGhost;i++) {
                string name = "";
                if (tag.Equals("horizontal")) name = "GhostLocation";
                else name = "GL";
                int num = (1+locationsPerGhost*(j/2)+i);
                name =name + num;
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
