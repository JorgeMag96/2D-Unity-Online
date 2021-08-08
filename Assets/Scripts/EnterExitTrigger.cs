using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class EnterExitTrigger : MonoBehaviour
{
    public int newSortingLayerOrder;
    public TilemapRenderer backSpriteRenderer;

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = newSortingLayerOrder;
        
        
        if (newSortingLayerOrder == 3) // Meaning we exit the building.
        {
            backSpriteRenderer.sortingOrder = 4;
        }
        else if (newSortingLayerOrder == 2) // Meaning we enter the building.
        {
            backSpriteRenderer.sortingOrder = 1;
        }
    }
}
