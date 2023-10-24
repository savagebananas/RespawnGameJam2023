using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Only attatch this script to the transparent barrell object
public class RotateTransparentBarrel : MonoBehaviour
{
    private static KeyCode key = KeyCode.R;
    private int i = 0; // 0: right, 1: up, 2: left, 3: down

    private GameObject rightBarrel;
    private GameObject upBarrel;

    private void Start()
    {
        rightBarrel = transform.GetChild(0).gameObject;
        upBarrel = transform.GetChild(1).gameObject;
        rightBarrel.SetActive(true);
        upBarrel.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            if(i < 3) i++;
                else i = 0;
        }
        setDirections();
    }

    void setDirections()
    {
        if (i == 0) //right
        {
            rightBarrel.SetActive(true);
            upBarrel.gameObject.SetActive(false);
            rightBarrel.GetComponent<BarrelTransparent>().setRight();
            rightBarrel.GetComponent<SpriteRenderer>().flipX = false;
            rightBarrel.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
        }
        if (i == 1) //up
        {
            rightBarrel.SetActive(false);
            upBarrel.gameObject.SetActive(true);
            upBarrel.GetComponent<BarrelTransparent>().setUp();
            upBarrel.GetComponent<SpriteRenderer>().flipY = false;
            upBarrel.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 90);
        }
        if (i == 2) //left
        {
            rightBarrel.SetActive(true);
            upBarrel.gameObject.SetActive(false);
            rightBarrel.GetComponent<BarrelTransparent>().setLeft();
            rightBarrel.GetComponent<SpriteRenderer>().flipX = true;
            rightBarrel.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 180);
        }
        if (i == 3) //down 
        {
            rightBarrel.SetActive(false);
            upBarrel.gameObject.SetActive(true);
            upBarrel.GetComponent<BarrelTransparent>().setDown();
            upBarrel.GetComponent<SpriteRenderer>().flipY = true;
            upBarrel.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
