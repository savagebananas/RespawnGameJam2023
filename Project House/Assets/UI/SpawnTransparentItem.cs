using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnTransparentItem : MonoBehaviour
{
    public GameObject parentUIObject;
    public GameObject transparentItem;

    public void instantiateTransparentItem()
    {
        if (!PlayerManager.mouseDragging)
        {
            Instantiate(transparentItem, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            if (parentUIObject != null) Destroy(parentUIObject);
            else Destroy(this.gameObject);
        }
    }
}
