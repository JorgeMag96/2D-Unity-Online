using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public GameObject teleportTo;
    public int newSortingLayerOrder;
    public List<SpriteRenderer> runes;
    public float lerpSpeed;

    private Vector3 teleportToPosition;
    private string teleportToSortingLayer;
    private Color curColor;
    private Color targetColor;

    private void Start()
    {
        if (teleportTo != null)
        {
            teleportToPosition = teleportTo.GetComponent<Transform>().position;
            teleportToSortingLayer = teleportTo.GetComponent<SpriteRenderer>().sortingLayerName;
        }
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (teleportTo != null)
        {
            var player = playerCollider.gameObject;
            var playerSortingLayer = player.GetComponent<SpriteRenderer>().sortingLayerName;
            
            if (gameObject.GetComponent<SpriteRenderer>().sortingLayerName.Equals(playerSortingLayer))
            {
                // Set the player layer to the destination layer.
                player.layer = teleportTo.layer;
                
                // Set the player sorting layer to the destination sorting layer. (This is case we teleport to a different floor)
                player.GetComponent<SpriteRenderer>().sortingLayerName = teleportToSortingLayer;
                var childrenSprites = player.GetComponentsInChildren<SpriteRenderer>();
                foreach ( var childrenSprite in childrenSprites)
                {
                    childrenSprite.sortingLayerName = teleportToSortingLayer;
                }
                
                // Set the player sorting layer order to the destination sorting layer order. (This is case we teleport outside of a building)
                player.GetComponent<SpriteRenderer>().sortingOrder = newSortingLayerOrder;
                
                // Finally we teleport the player to the destination position.
                var playerTransform = player.GetComponent<Transform>();
                playerTransform.position =
                    new Vector3(teleportToPosition.x, teleportToPosition.y, playerTransform.position.z);
            }
        }
        
        targetColor = new Color(1, 1, 1, 1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (var r in runes)
        {
            r.color = curColor;
        }
    }
}
