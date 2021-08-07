using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; //what to follow
    private Vector3 offset = new Vector3(0, 0, -10);

    public float smoothSpeed = 0.125f;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate() {
        if(playerTransform != null)
            transform.position = playerTransform.position + offset;
    }
}
