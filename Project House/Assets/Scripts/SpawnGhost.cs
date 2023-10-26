using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    public int index;
    public static GameObject[] locations = new GameObject[4];
    public static bool hasMoved = false;
    private int length = 4;
    GameObject obj;
    void Start()
    {
        for (int i = 1; i<=locations.Length;i++) {
            string name = "GhostLocation" + i;
            Debug.Log(name);
            locations[i-1] = GameObject.Find(name);
        }
            obj = Instantiate(ghost, getRandomPosition(), Quaternion.identity);
            hasMoved = true;
    }
    

    // Update is called once per frame
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
        obj.GetComponent<GhostMovement>().updatePositions();
        obj.GetComponent<Animator>().SetTrigger("fadeIn");
    }

    private Vector3 getRandomPosition() {
        int temp = index;
        int loopCount = 0;
        bool x = true;
        while ((temp==index||!locations[temp].GetComponent<GhostLocationRadius>().shouldSpawn||x)&&loopCount<50) {
            RaycastHit2D hit = Physics2D.Raycast(locations[temp].transform.position, Vector2.zero);
            x = hit.collider!=null&&!hit.collider.gameObject.tag.Equals("phone")&&hit.collider.gameObject.layer!=5;
            temp = Random.Range(0, length);
            loopCount++;

        }
        if (loopCount>=50) {
            Debug.Log("spawnGhost :" + temp);
            Debug.Log("spawnGhost :" + locations[temp]);
        }
        index = temp;
        return locations[index].transform.position;
    }
    

}
