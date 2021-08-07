using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public GameObject teleportTo;
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
            var playerSortingLayer = playerCollider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            if (gameObject.GetComponent<SpriteRenderer>().sortingLayerName.Equals(playerSortingLayer))
            {
                playerCollider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = teleportToSortingLayer;
                var playerTransform = playerCollider.gameObject.GetComponent<Transform>();
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
