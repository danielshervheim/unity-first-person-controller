using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New Blended Input Provider", menuName = "DSS/Player/Input Providers/Blended Provider")]
    public class BlendedInputProvider : PlayerInputProvider
    {
        [SerializeField] private PlayerInputProvider a = default;
        [SerializeField] private PlayerInputProvider b = default;
        [SerializeField][Range(0f,1f)] private float blend = 0f;

        public override float GetMoveHorizontal()
        {
            return Mathf.Lerp(a.GetMoveHorizontal(), b.GetMoveHorizontal(), blend);
        }

        public override float GetMoveVertical()
        {
            return Mathf.Lerp(a.GetMoveVertical(), b.GetMoveVertical(), blend);
        }


        public override float GetLookHorizontal()
        {
            return Mathf.Lerp(a.GetLookHorizontal(), b.GetLookHorizontal(), blend);
        }

        public override float GetLookVertical()
        {
            return Mathf.Lerp(a.GetLookVertical(), b.GetLookVertical(), blend);
        }

        public override bool GetJump()
        {
            return blend < 0.5f ? a.GetJump() : b.GetJump();
        }
    }
}
