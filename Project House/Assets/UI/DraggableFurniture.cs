using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add to furniture that can be dragged. Must manually set transparentItem to the transparent prefab of the
//game object in Unity Editor.
public class DraggableFurniture : MonoBehaviour
{
    public bool hasBeenDragged;
    public bool isBreaking = false;
    public GameObject transparentItem;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.mouseDragging = false;
        AstarPath.active.Scan();
        if (!hasBeenDragged) {
            gameObject.tag = "Untagged";
            gameObject.layer = 6;        
        }
        if (hasBeenDragged) {
            gameObject.tag = "breakable";
            gameObject.layer = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("furniture test");
        if(!PlayerManager.mouseDragging&&!isBreaking) {
            Vector3 t = transform.position;
            Instantiate(transparentItem, t, Quaternion.identity);
            StartCoroutine(DestroySelf());
            return;
        }
    }
    void OnMouseExit() {
        //TODO Disable Highlight
    }

    IEnumerator DestroySelf()
    {
        
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);

    }
}
