using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private GameObject transparentItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transparentItem!=null) {
            Instantiate(transparentItem);
            transparentItem = null;
        }
    }
    public void setItem(GameObject item) {
        transparentItem = item;
    }
}
