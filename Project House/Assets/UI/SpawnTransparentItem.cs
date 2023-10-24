using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTransparentItem : MonoBehaviour
{
    public GameObject transparentItem;

    public void instantiateTransparentItem()
    {
        if (!PlayerManager.mouseDragging)
        {
            Instantiate(transparentItem, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
