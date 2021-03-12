using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New FirstPerson Controller", menuName = "DSS/Player/Controllers/FirstPerson Controller")]
    public class FirstPersonController : PlayerController
    {
        [Header("Pitch Contraints")]
        [SerializeField] private float minPitch = -90f;
        [SerializeField] private float maxPitch = 90f;

        [Header("Transform Offsets")]
        [SerializeField] private Vector3 headOffset = Vector3.up*0.75f;
        [SerializeField] private Vector3 eyeOffset = Vector3.zero;


        public override void UpdatePitch(float verticalLookInput)
        {
            base.UpdatePitch(verticalLookInput);
            _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);
        }

        public override Quaternion GetRootRotation()
        {
            return Quaternion.Euler(Vector3.up * _yaw);
        }

        public override Vector3 GetHeadLocalPosition()
        {
            return headOffset;
        }

        public override Quaternion GetHeadLocalRotation()
        {
            return Quaternion.Euler(Vector3.right * _pitch);
        }

        public override Vector3 GetEyesLocalPosition()
        {
            return eyeOffset;
        }

        public override Quaternion GetEyesLocalRotation()
        {
            return Quaternion.identity;
        }
    }
}

