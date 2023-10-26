using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHighlight : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject light;
    private GameObject highlight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter() {
        highlight = Instantiate(light, transform);

    }
    void OnMouseExit() {
        Destroy(highlight);
    }
    public static void setLight(GameObject hl) {
        light = hl;
    }
}
