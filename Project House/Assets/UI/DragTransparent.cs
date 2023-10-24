using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make a new gameobject with the same sprite as the item you want to 
//drag into the game(do not use the same game object)
//Once you attatch this script you must attatch the prefab gameobject as the value of the variable item
public class DragTransparent : MonoBehaviour
{
    private static Color noColl = new Color(0, 0, 255, 0.4f);
    private static Color coll = new Color(255, 0, 0, 0.4f);
    SpriteRenderer sr;
    private bool dragging = true;
    private int collcount = 0;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = noColl;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        sr.color = coll;
        collcount++;
    }
    void OnTriggerExit2D(Collider2D collider) {
        collcount--;
        if (!isColliding()) sr.color = noColl;
    }
    void OnMouseDown() {
        if (!isColliding()) {
            dragging = false;
            Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    bool isColliding() {
        if (collcount == 0) return false;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousepos.x, mousepos.y, transform.position.z);
        }


    }
}