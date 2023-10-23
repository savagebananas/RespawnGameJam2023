using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Only attatch this script to the transparent barrell object
public class RotateBarrell : MonoBehaviour
{
    private static KeyCode key = KeyCode.X;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
