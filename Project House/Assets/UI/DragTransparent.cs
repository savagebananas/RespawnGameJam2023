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
    //private int collcount = 0;
    public GameObject item;
    private Rigidbody2D rb;
    public float v = 40f;
    public List<Collider2D> colliders = new List<Collider2D>();
    private List<bool> shouldRemove = new List<bool>();
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sr.color = noColl;
        PlayerManager.mouseDragging = true;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 5) return;
        if (collider.gameObject.layer == 2) return;
        if (collider.gameObject.tag.Equals("phone")) return;
        sr.color = coll;
        //collcount++;
        if (!colliders.Contains(collider)) {
            colliders.Add(collider);
            shouldRemove.Add(false);
        }
    }
    void OnTriggerExit2D(Collider2D collider) {
        //collcount--;
        if (collider.gameObject.layer == 5) return;
        if (collider.gameObject.layer == 2) return;
        if (!isColliding()) sr.color = noColl;
        if (colliders.Contains(collider)) {
            shouldRemove.RemoveAt(colliders.IndexOf(collider));
            colliders.Remove(collider);
        }
    }
    void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.layer == 5) return;
        if (collider.gameObject.layer == 2) return;
        if (collider.gameObject.tag=="phone") return;
        if (colliders.Contains(collider)) shouldRemove[colliders.IndexOf(collider)] = false;
        else {
            colliders.Add(collider);
            shouldRemove.Add(false);
        }
    }
    void OnMouseDown() {
        if (!isColliding()) {
            dragging = false;
            GameObject f = Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("PlaceObj");
            if (f.GetComponent<DraggableFurniture>() != null) f.GetComponent<DraggableFurniture>().hasBeenDragged = true;
            Destroy(this.gameObject);
        }
        else {
            Debug.Log("transp problem : " + isColliding() + "  " + colliders.Count);
        }
    }
    bool isColliding() {
        if (colliders.Count == 0) return false;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        int count = colliders.Count;
        for (int i = 0; i<count; i++) {
   
            bool x = shouldRemove[i];
            if (x) {
                if (colliders.Count>i) {
                    colliders.RemoveAt(i);
                    shouldRemove.RemoveAt(i);
                    count--;
                }
            }
        }
        if (!isColliding()) {
            sr.color = noColl;
        }
        if (dragging) {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vel = new Vector2(mousepos.x-transform.position.x, mousepos.y-transform.position.y);
            rb.velocity = vel*v;

        }
        for (int i = 0; i<shouldRemove.Count; i++) {
            if (shouldRemove.Count>i) {
                shouldRemove[i] = false;
            }
        }
        if (Mathf.Abs(Time.time-20)<0.1) Debug.Log("Couch Test : " + colliders.Count);
    }
}
