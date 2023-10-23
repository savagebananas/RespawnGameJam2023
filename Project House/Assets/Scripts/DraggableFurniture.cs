using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add to furniture that can be dragged. Must manually set transparentItem to the transparent prefab of the
//game object in Unity Editor.
public class DraggableFurniture : MonoBehaviour
{
    private bool mouseIsOver;
    public GameObject transparentItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter() {
        mouseIsOver = true;
    }
    void OnMouseDown() {
        if(mouseIsOver && !PlayerManager.mouseDragging) {
            Vector3 t = transform.position;
            Instantiate(transparentItem, t, Quaternion.identity);
            PlayerManager.mouseDragging = true;
        }
    }
}
