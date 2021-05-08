using UnityEngine;

namespace DSS.PlayerControllers
{
    // @brief Implements a simple first-person style character controller.
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        [Header("Required References")]
        [SerializeField] private Transform body = default;
        public Transform Body {
            get {
                return body;
            }
        }
        [SerializeField] private Camera eyes = default;
        public Camera Eyes {
            get {
                return eyes;
            }
        }

        [Header("Pause")]
        public bool paused = false;

        [Header("Move")]
        [SerializeField] private string horizontalMovementAxis = "Horizontal";
        [SerializeField] private string verticalMovementAxis = "Vertical";
        [SerializeField] private float movementSpeed = 5f;
        public float MoveSpeed
        {
            get
            {
                return movementSpeed;
            }
            set
            {
                movementSpeed = Mathf.Max(0f, value);
            }
        }

        [Header("Look")]
        [SerializeField] private string horizontalLookAxis = "Mouse X";
        [SerializeField] private string verticalLookAxis = "Mouse Y";
        [SerializeField] private float lookSpeed = 80f;
        public float LookSpeed
        {
            get
            {
                return lookSpeed;
            }
            set
            {
                lookSpeed = Mathf.Max(0f, value);
            }
        }

        [SerializeField][Range(-90f, 90f)] private float minimumPitch = -90f;
        [SerializeField][Range(-90f, 90f)] private float maximumPitch =  90f;

        [Header("Jump")]
        [SerializeField] private string jumpButton = "Jump";
        [SerializeField] private float gravity = -9.8f;
        public float Gravity
        {
            get
            {
                return gravity;
            }
            set
            {
                if (gravity > 0f) {
                    Debug.LogWarning("Gravity is greater than 0. This is unexpected...");
                }
                gravity = value;
            }
        }

        [SerializeField] private float jumpForce = 5f;
        public float JumpForce
        {
            get
            {
                return jumpForce;
            }
            set
            {
                jumpForce = Mathf.Max(0f, value);
            }
        }
        [SerializeField] private float terminalVelocity = 9.8f;
        public float TerminalVelocity
        {
            get
            {
                return terminalVelocity;
            }
            set
            {
                terminalVelocity = Mathf.Max(0f, value);
            }
        }

        private Vector3 originalPosition;
        private float originalYaw;

        private CharacterController controller;
        private float pitch = 0f;
        private float yaw = 0f;
        private Vector3 jumpVector = Vector3.zero;

        // @brief Moves the player back to the position they were when the scene loaded.
        public void ResetPosition()
        {
            Teleport(originalPosition);
        }

        // @brief Rotates the player's camera to the direction it was facing when the scene loaded.
        public void ResetRotation()
        {
            pitch = 0f;
            yaw = originalYaw;
        }

        // @brief Moves the player to the given position.
        public void Teleport(Vector3 newPosition)
        {
            // Disable controller while moving to avoid hiccups
            controller.enabled = false;
            body.position = newPosition;
            controller.enabled = true;
        }

        // // TODO: implement this.
        // @brief Rotates the player's camera to face the given target.
        // public void LookAt(Vector3 lookTarget)
        // {
        // 
        // }

        private void Awake()
        {
            yaw = body.rotation.eulerAngles.y;
            originalYaw = yaw;
            originalPosition = body.position;
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Compute movement input.
            Vector3 movementInput = Vector3.zero;
            if (!paused) {
                movementInput = new Vector3(
                    Input.GetAxis(horizontalMovementAxis),
                    0,
                    Input.GetAxis(verticalMovementAxis)
                );
            }
            movementInput = Vector3.ClampMagnitude(movementInput, 1f);  // Prevents 1.41 speed at when moving diagonally.

            // Update the jump vector.
            if (!paused && controller.isGrounded && Input.GetButton(jumpButton))
            {
                jumpVector = Vector3.up * jumpForce;
            }
            jumpVector += gravity*Vector3.up * Time.deltaTime;
            jumpVector = Vector3.ClampMagnitude(jumpVector, terminalVelocity);

            // Compute movement delta vector.
            Vector3 movementDelta = Vector3.zero;
            movementDelta += body.right * movementInput.x * movementSpeed;
            movementDelta += jumpVector + gravity*Vector3.up*Time.deltaTime;
            movementDelta += body.forward * movementInput.z * movementSpeed;

            // And finally, move the controller.
            controller.Move(movementDelta * Time.deltaTime);
        }

        private void LateUpdate()
        {
            // Update the pitch and yaw.
            float deltaYaw = 0f;
            float deltaPitch = 0f;
            if (!paused)
            {
                deltaYaw = Input.GetAxis(horizontalLookAxis) * lookSpeed * Time.deltaTime;
                deltaPitch = Input.GetAxis(verticalLookAxis) * lookSpeed * Time.deltaTime;
            }
            yaw += deltaYaw;
            pitch -= deltaPitch;
            pitch = Mathf.Clamp(pitch, minimumPitch, maximumPitch);

            // Set the rotations based on the pitch and yaw.
            eyes.transform.localRotation = Quaternion.Euler(Vector3.right * pitch);
            body.localRotation = Quaternion.Euler(Vector3.up * yaw);
        }
    }
}
