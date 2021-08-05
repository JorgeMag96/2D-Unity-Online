using System;
using Mirror;
using UnityEngine;

    public class CharacterController : NetworkBehaviour
    {
        public float speed;

        private Animator animator;
        private Rigidbody2D rb;

        private Vector2 dir;
        
        private float xInput;
        private float yInput;

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
            
            HandleMovement();
            HandleAnimation();
            
            rb.velocity = speed * dir;
        }

        private void HandleMovement()
        {
            dir = Vector2.zero;
            
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            
            dir.x = xInput;
            dir.y = yInput;
                
            dir.Normalize();
        }

        private void HandleAnimation()
        {
            if (dir.x < 0)
            {
                animator.SetInteger("Direction", 3);
            }
            else if (dir.x > 0)
            {
                animator.SetInteger("Direction", 2);
            }
                
            if (dir.y > 0)
            {
                animator.SetInteger("Direction", 1);
            }
            else if (dir.y < 0)
            {
                animator.SetInteger("Direction", 0);
            }
            
            animator.SetBool("IsMoving", dir.magnitude > 0);
        }
        
    }

