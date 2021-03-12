
using UnityEngine;

namespace DSS.PlayerControllers
{
    public abstract class PlayerController : ScriptableObject
    {
        [Header("Behaviour")]
        [SerializeField] private float lookSpeed = 80f;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpForce = 5f;

        // behaviour properties.
        public float LookSpeed { get { return lookSpeed; } set { lookSpeed = Mathf.Max(value, 0); } }
        public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = Mathf.Max(value, 0); } }
        public float JumpForce { get { return jumpForce; } set { jumpForce = Mathf.Max(value, 0); } }

        protected float _pitch = 0f;
        protected float _yaw = 0f;

        public virtual void Reset()
        {
            _pitch = 0f;
            _yaw = 0f;
        }

        public virtual void UpdatePitch(float verticalLookInput)
        {
            _pitch -= verticalLookInput * lookSpeed * Time.deltaTime;
        }

        public virtual void UpdateYaw(float horizontalLookInput)
        {
            _yaw += horizontalLookInput * lookSpeed * Time.deltaTime;
        }

        public abstract Quaternion GetRootRotation();

        public abstract Vector3 GetHeadLocalPosition();
        public abstract Quaternion GetHeadLocalRotation();

        public abstract Vector3 GetEyesLocalPosition();
        public abstract Quaternion GetEyesLocalRotation();
    }
}

