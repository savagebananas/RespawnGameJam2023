using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    public int index = -1;
    public static GameObject[] locations = new GameObject[6];
    public bool hasMoved = false;
    private int length = 6;
    GameObject obj;
    public GameObject pointer;
    GameObject pnt;
    void Start()
    {
        for (int i = 1; i<=locations.Length;i++) {
            string name = "GhostLocation" + i;
            Debug.Log(name);
            locations[i-1] = GameObject.Find(name);
        }
            obj = Instantiate(ghost, getRandomPosition(), Quaternion.identity);
            pnt = Instantiate(pointer);
            pnt.GetComponent<Pointer>().
            hasMoved = true;
            StartCoroutine(setHasMoved());
    }
    

    // Update is called once per frame
    IEnumerator setHasMoved() {
        yield return new WaitForSeconds(0.06f);
        hasMoved = false;
    }
    void Update()
    {
        if (Time.time>0.05&&Mathf.Abs(Time.time%10) < 0.05&&!hasMoved) {
            StartCoroutine(respawnGhost());
        }
    }

    IEnumerator respawnGhost()
    {
        obj.GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        obj.transform.position = getRandomPosition();
        obj.transform.rotation = Quaternion.identity;
        hasMoved = true;
        StartCoroutine(setHasMoved());
        obj.GetComponent<GhostMovement>().updatePositions();
        obj.GetComponent<Animator>().SetTrigger("fadeIn");
    }

    private Vector3 getRandomPosition() {
        if (index==-1) {
            index = Random.Range(0, length);
            return locations[index].transform.position;
        }
        int temp = index;
        List<GameObject> tmp = new List<GameObject>();
        foreach (GameObject x in locations) {
            if (x.GetComponent<GhostLocationRadius>().getShouldSpawn()) {
                tmp.Add(x);
            }
        tmp.Remove(locations[index]);
        }
        if (tmp.Count>0) {
            temp = Random.Range(0, tmp.Count);
        }

        
        index = temp;
        return locations[index].transform.position;
    }
    

}
