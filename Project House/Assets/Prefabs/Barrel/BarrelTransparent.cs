using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTransparent : MonoBehaviour
{
    public bool isMovingUp = false;
    public bool isMovingDown = false;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    private static Color noColl = new Color(135, 144, 133, 0.8f);
    private static Color coll = new Color(255, 0, 0, 0.5f);
    SpriteRenderer sr;
    private bool dragging = true;
    private int collcount = 0;
    public GameObject item;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = noColl;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.parent.position = new Vector3(mousepos.x, mousepos.y, transform.position.z);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        sr.color = coll;
        collcount++;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        collcount--;
        if (!isColliding()) sr.color = noColl;
    }
    void OnMouseDown()
    {
        if (!isColliding())
        {
            dragging = false;
            var o = Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            Barrel barrel = o.GetComponent<Barrel>();
            barrel.isMovingDown = isMovingDown;
            barrel.isMovingUp = isMovingUp;
            barrel.isMovingLeft = isMovingLeft;
            barrel.isMovingRight = isMovingRight;
            Destroy(this.gameObject);
        }
    }
    bool isColliding()
    {
        if (collcount == 0) return false;
        return true;
    }

    public void setRight()
    {
        isMovingUp = false;
        isMovingDown = false;
        isMovingLeft = false;
        isMovingRight = true;
    }

    public void setLeft()
    {
        isMovingUp = false;
        isMovingDown = false;
        isMovingLeft = true;
        isMovingRight = false;
    }

    public void setUp()
    {
        isMovingUp = true;
        isMovingDown = false;
        isMovingLeft = false;
        isMovingRight = false;
    }

    public void setDown()
    {
        isMovingUp = false;
        isMovingDown = true;
        isMovingLeft = false;
        isMovingRight = false;
    }
}
