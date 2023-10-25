using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSort : MonoBehaviour
{
    public bool isStatic = false;

    private int baseSortingOrder;
    public Transform bottomOfSprite;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -(int)(bottomOfSprite.position.y * 250);
    }

    private void Update()
    {
        if (!isStatic) sprite.sortingOrder = -(int) (bottomOfSprite.position.y * 250);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(bottomOfSprite.transform.position, 0.05f);
    }
}
