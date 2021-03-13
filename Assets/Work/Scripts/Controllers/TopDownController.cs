using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New TopDown Controller", menuName = "DSS/Player/Controllers/TopDown Controller")]
    public class TopDownController : PlayerController
    {
        [Header("Pitch Contraints")]
        [SerializeField] private float minPitch = 0f;
        [SerializeField] private float maxPitch = 90f;

        [Header("Zoom Constraints")]
        [SerializeField] private float minZoom = 10f;
        [SerializeField] private float maxZoom = 100f;

        private float _zoom = 10f;

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
            return Vector3.zero;
        }

        public override Quaternion GetHeadLocalRotation()
        {
            return Quaternion.Euler(Vector3.right * _pitch);
        }

        public override Vector3 GetEyesLocalPosition()
        {
            return -Vector3.forward*_zoom;
        }

        public override Quaternion GetEyesLocalRotation()
        {
            return Quaternion.identity;
        }
    }
}
