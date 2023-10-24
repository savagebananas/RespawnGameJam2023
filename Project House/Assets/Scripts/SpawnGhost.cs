using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector2 size;
    public GameObject ghost;
    public static Vector3[][] positions = new Vector3[1][];
    void Start()
    {
        positions[0] = new Vector3[3];
        positions[0][0] = new Vector3(-3.62f, 8.45f, 0f);
        positions[0][1] = new Vector3(-9.38f, 8.45f, 0f);
        positions[0][2] = new Vector3(1.12f, 8.45f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>0.01&&Mathf.Abs(Time.time%10) < 0.01) {
            Instantiate(ghost, getRandomPosition(), Quaternion.identity);
        }
    }
    private Vector3 getRandomPosition() {
        int index = Random.Range(0, positions.Length);
        return positions[index][0];
    }
}
