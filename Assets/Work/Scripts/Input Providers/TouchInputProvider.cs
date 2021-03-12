using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New Touch Input Provider", menuName = "DSS/Player/Input Providers/Touch Provider")]
    public class TouchInputProvider : PlayerInputProvider
    {
        // TODO: implement this.

        public override float GetMoveHorizontal()
        {
            return 0f;
        }

        public override float GetMoveVertical()
        {
            return 0f;
        }


        public override float GetLookHorizontal()
        {
            return 0f;
        }

        public override float GetLookVertical()
        {
            return 0f;
        }

        public override bool GetJump()
        {
            return false;
        }
    }
}
