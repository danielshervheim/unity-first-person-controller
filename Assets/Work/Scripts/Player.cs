using UnityEngine;

namespace DSS.PlayerControllers
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [Header("Drivers")]
        [SerializeField] private PlayerController controller = default;
        [SerializeField] private PlayerInputProvider input = default;

        [Header("Required References")]
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Transform playerHead = default;
        [SerializeField] private Transform playerEyes = default;

        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            // Validate transform hierarchy setup. 
            if (playerRoot != this.transform)
            {
                Debug.LogError("The Player class expects to be attached to the \"playerRoot\" transform.");
            }
            if (playerHead.parent != playerRoot)
            {
                Debug.LogError("The Player class expects to the \"playerHead\" transform to be a child of the \"playerRoot\" transform.");
            }
            if (playerEyes.parent != playerHead)
            {
                Debug.LogError("The Player class expects to the \"playerEyes\" transform to be a child of the \"playerHead\" transform.");
            }

            // Reset the controller, otherwise the pitch and yaw from the previous run will be used.
            controller.Reset();
        }

        private void Update()
        {
            float moveHorizontal = input.GetMoveHorizontal();
            float moveVertical = input.GetMoveVertical();
            
            // Limit movement to 1, to avoid 1.41 speed movement
            float magnitude = Mathf.Sqrt(Mathf.Pow(moveHorizontal, 2f) + Mathf.Pow(moveVertical, 2f));
            if (!Mathf.Approximately(magnitude, 0f))
            {
                moveHorizontal /= magnitude;
                moveVertical /= magnitude;
            }

            // And scale by the movement speed.
            moveHorizontal *= controller.MoveSpeed;
            moveVertical *= controller.MoveSpeed;

            // TODO: implement jumping.
            
            // Compute movement vector.
            Vector3 movement = Vector3.zero;
            movement += playerRoot.right*moveHorizontal;
            movement -= Vector3.up*9.8f;
            movement += playerRoot.forward*moveVertical;
            _characterController.Move(movement*Time.deltaTime);
        }

        private void LateUpdate()
        {
            // Update the pitch and yaw of the camera.
            controller.UpdatePitch(input.GetLookVertical());
            controller.UpdateYaw(input.GetLookHorizontal());

            // And apply the newly calculated local rotations and local positions
            // to the transform hierarchy.
            playerRoot.rotation = controller.GetRootRotation();
            playerHead.localPosition = controller.GetHeadLocalPosition();
            playerHead.localRotation = controller.GetHeadLocalRotation();
            playerEyes.localPosition = controller.GetEyesLocalPosition();
            playerEyes.localRotation = controller.GetEyesLocalRotation();

            // TODO: implement FOV / zooming
        }
    }
}