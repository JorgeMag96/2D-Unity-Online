using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public Transform teleportTo;
    public bool teleportationEnabled;
    public List<SpriteRenderer> runes;
    public float lerpSpeed;

    private Color curColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (teleportTo != null && teleportationEnabled)
        {
            var playerTransform = playerCollider.gameObject.GetComponent<Transform>();
            playerTransform.position = teleportTo.position;
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
