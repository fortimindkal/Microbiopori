using System.Collections;
using UnityEngine;

namespace Microbiopori
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f; // Adjust the player's movement speed in the Inspector.
        public FloatingJoystick joystick;

        public Canvas inputCanvas;
        public bool isJoystick;

        private Rigidbody2D rb;
        private Animator anim;
        private float horizontalInput;

        // Variables for touch input.
        private Vector2 touchStartPos;
        private bool isSwiping = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            EnableJoystickInput();
        }

        private void Update()
        {
            // Handle touch input.
            //HandleTouchInput();

            // Get horizontal input from the player (e.g., left and right arrow keys or A and D keys).
            // Only use this input if no swipe is detected.
            if (!isSwiping)
            {
                horizontalInput = Input.GetAxis("Horizontal");
            }

            if(isJoystick)
            {
                horizontalInput = joystick.Horizontal;
                Move(horizontalInput);
            }

            MoveAnimation();
        }

        public void EnableJoystickInput()
        {
            isJoystick = true;
            inputCanvas.gameObject.SetActive(true);
        }

        private void MoveAnimation()
        {
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //Set Animator
            anim.SetBool("isMove", horizontalInput != 0);
        }

        private void FixedUpdate()
        {
            // Apply horizontal movement to the player.
            Move(horizontalInput);
        }

        private void Move(float moveInput)
        {
            // Calculate the new velocity based on the input and speed.
            Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // Apply the velocity to the player's Rigidbody.
            rb.velocity = movement;

            // You can also add jumping logic or other interactions here.
        }

        public void SetPlayerDead()
        {
            //anim.SetTrigger("isDead");
            StartCoroutine(SetupPlayerCompleteDead());
        }

        public void SetPlayerDamaged()
        {
            anim.SetBool("isHurt", true);
            StartCoroutine(SetPlayerCompleteDamaged());
        }

        public IEnumerator SetPlayerCompleteCollection()
        {
            Debug.Log("Delay 3 seconds");
            yield return new WaitForSeconds(1.0f); // Adjust the duration as per your animation length.
            anim.SetBool("isCollect", false);
            Debug.Log("Collect Done.");
        }

        public IEnumerator SetPlayerCompleteDamaged()
        {
            Debug.Log("Delay 3 seconds");
            yield return new WaitForSeconds(1.0f); // Adjust the duration as per your animation length.
            anim.SetBool("isHurt", false);
            Debug.Log("Damaged Done.");
        }

        public IEnumerator SetupPlayerCompleteDead()
        {
            Debug.Log("Delay 3 seconds");
            anim.SetTrigger("isDead");
            yield return new WaitForSeconds(1.0f); // Adjust the duration as per your animation length.
            GameManager.Instance.GameOver();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPos = touch.position;
                        isSwiping = true;
                        break;

                    case TouchPhase.Moved:
                        float swipeDeltaX = touch.position.x - touchStartPos.x;
                        horizontalInput = swipeDeltaX * 0.01f; // Adjust the sensitivity if needed.
                        break;

                    case TouchPhase.Ended:
                        isSwiping = false;
                        horizontalInput = 0f;
                        break;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collectible"))
            {
                anim.SetBool("isCollect", true);
                StartCoroutine(SetPlayerCompleteCollection());
            }
        }
    }
}
