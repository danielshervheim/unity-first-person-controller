using UnityEngine;

namespace DSS.FirstPersonController
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform body = default;
        [SerializeField] Camera eyes = default;

        [Header("Pause")]
        public bool paused = false;

        [Header("Move")]
        [SerializeField] string horizontalMovementAxis = "Horizontal";
        [SerializeField] string verticalMovementAxis = "Vertical";
        public float movementSpeed = 5f;

        [Header("Look")]
        [SerializeField] string horizontalLookAxis = "Mouse X";
        [SerializeField] string verticalLookAxis = "Mouse Y";
        public float lookSpeed = 80f;
        [SerializeField][Range(-90f, 90f)] float minimumPitch = -90f;
        [SerializeField][Range(-90f, 90f)] float maximumPitch =  90f;

        [Header("Jump")]
        [SerializeField] string jumpButton = "Jump";
        [SerializeField] float gravity = -9.8f;
        [SerializeField] float jumpForce = 5f;

        // [Header("Swim")]

        // [Header("Climb")]

        CharacterController controller;
        float pitch = 0f;
        float yaw = 0f;
        Vector3 jumpVector = Vector3.zero;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
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
            movementInput = Vector3.ClampMagnitude(movementInput, 1f);  // Prevent 1.41 speed at when moving diagonally.

            // Update the jump vector.
            if (!paused && controller.isGrounded && Input.GetButton(jumpButton))
            {
                jumpVector = Vector3.up * jumpForce;
            }
            jumpVector += gravity*Vector3.up * Time.deltaTime;
            // TODO: something wrong with this when the player falls of w/o jumping.

            // Compute movement delta vector.
            Vector3 movementDelta = Vector3.zero;
            movementDelta += body.right * movementInput.x * movementSpeed;
            movementDelta += jumpVector + gravity*Vector3.up*Time.deltaTime;
            movementDelta += body.forward * movementInput.z * movementSpeed;

            // And finally, move the controller.
            controller.Move(movementDelta * Time.deltaTime);
        }

        void LateUpdate()
        {
            // Update the pitch and yaw.
            if (!paused)
            {
                yaw += Input.GetAxis(horizontalLookAxis) * lookSpeed * Time.deltaTime;
                pitch -= Input.GetAxis(verticalLookAxis) * lookSpeed * Time.deltaTime;
            }
            pitch = Mathf.Clamp(pitch, minimumPitch, maximumPitch);

            // Set the rotations based on the pitch and yaw.
            eyes.transform.localRotation = Quaternion.Euler(Vector3.right * pitch);
            body.localRotation = Quaternion.Euler(Vector3.up * yaw);
        }
    }
}
