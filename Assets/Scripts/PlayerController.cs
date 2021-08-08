using System;
using Mirror;
using UnityEngine;

    public class PlayerController : NetworkBehaviour
    {
        public float speed = 3f;

        private Animator animator;
        private Rigidbody2D rb;

        private Vector2 movement;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        public override void OnStartLocalPlayer()
        {
            Camera.main.GetComponent<CameraFollow>().playerTransform = transform; //Fix camera on "me" 
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            
            ProcessInputs();
            HandleAnimation();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }

        private void ProcessInputs()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void HandleAnimation()
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
    }

