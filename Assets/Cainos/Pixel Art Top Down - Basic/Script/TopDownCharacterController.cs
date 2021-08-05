using Mirror;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : NetworkBehaviour
    {
        public float speed;

        private Animator animator;
        private Rigidbody2D rb;

        private Vector2 dir;
        private float xInput;
        private float yInput;

        public override void OnStartLocalPlayer()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            
            ProcessInputs();

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Direction", 0);
            }
            
            animator.SetBool("IsMoving", dir.magnitude > 0);
        }
        
        private void FixedUpdate() {
            if (!isLocalPlayer) return;

            rb.velocity = speed * dir;
        }

        private void ProcessInputs()
        {
            dir = Vector2.zero;
            
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            dir.x = xInput;
            dir.y = yInput;
            
            dir.Normalize();
        }
        
    }
}
