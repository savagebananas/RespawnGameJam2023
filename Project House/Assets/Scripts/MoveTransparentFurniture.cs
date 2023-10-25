using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The transparent furniture should have a kinematic rigid body and is trigger
//should be enabled. This object should only be spawned if PlayerManager.mouseIsDragging = false.
public class MoveTransparentFurniture : MonoBehaviour
{
    private static Color noColl = new Color(0, 0, 255, 0.4f);
    private static Color coll = new Color(255, 0, 0, 0.4f);
    SpriteRenderer sr;
    private bool dragging = true;
    private int collcount = 0;
    public GameObject item;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.mouseDragging = true;
        sr = GetComponent<SpriteRenderer>();
        sr.color = noColl;
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag=="phone") return;
        sr.color = coll;
        collcount++;
    }
    void OnTriggerExit2D(Collider2D collider) {
        collcount--;
        if (!isColliding()) sr.color = noColl;
    }
    void OnMouseDown() {

        if (!isColliding()&&dragging) {
            dragging = false;
            PlayerManager.mouseDragging = false;
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
            Vector2 vel = new Vector2(mousepos.x-transform.position.x, mousepos.y-transform.position.y);
            rb.velocity = vel*15f;
        }


    }
     
}
