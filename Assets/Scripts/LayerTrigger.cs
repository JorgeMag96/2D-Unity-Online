using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //when object exit the trigger, put it to the assigned sorting layer
    //used in the stair objects for player to travel between sorting layers
    public class LayerTrigger : MonoBehaviour
    {
        public string layer;
        public string sortingLayer;

        private void OnTriggerExit2D(Collider2D other)
        {

            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
            
            var childrenSprites = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach ( var childrenSprite in childrenSprites)
            {
                childrenSprite.sortingLayerName = sortingLayer;
            }
        }

    }
}
