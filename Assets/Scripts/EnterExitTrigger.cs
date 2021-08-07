using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitTrigger : MonoBehaviour
{
    public int newSortingLayerOrder;

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = newSortingLayerOrder;
    }
}
