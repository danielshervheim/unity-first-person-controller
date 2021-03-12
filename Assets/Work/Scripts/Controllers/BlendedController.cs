using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New Blended Controller", menuName = "DSS/Player/Controllers/Blended Controller")]
    public class BlendedController : PlayerController
    {
        [SerializeField] private PlayerController a = default;
        [SerializeField] private PlayerController b = default;
        [SerializeField][Range(0f,1f)] private float blend = 0f;

        public override void Reset()
        {
            a.Reset();
            b.Reset();
        }

        public override void UpdatePitch(float verticalLookInput)
        {
            a.UpdatePitch(verticalLookInput);
            b.UpdatePitch(verticalLookInput);     
        }

        public override void UpdateYaw(float horizontalLookInput)
        {
            a.UpdateYaw(horizontalLookInput);
            b.UpdateYaw(horizontalLookInput);     
        }

        public override Quaternion GetRootRotation()
        {
            return Quaternion.Slerp(a.GetRootRotation(), b.GetRootRotation(), blend);
        }

        public override Vector3 GetHeadLocalPosition()
        {
            return Vector3.Lerp(a.GetHeadLocalPosition(), b.GetHeadLocalPosition(), blend);
        }

        public override Quaternion GetHeadLocalRotation()
        {
            return Quaternion.Slerp(a.GetHeadLocalRotation(), b.GetHeadLocalRotation(), blend);
        }

        public override Vector3 GetEyesLocalPosition()
        {
            return Vector3.Lerp(a.GetEyesLocalPosition(), b.GetEyesLocalPosition(), blend);
        }

        public override Quaternion GetEyesLocalRotation()
        {
            return Quaternion.Slerp(a.GetEyesLocalRotation(), b.GetEyesLocalRotation(), blend);
        }
    }
}

