using UnityEngine;

namespace DSS.PlayerControllers
{
    [CreateAssetMenu(fileName = "New Keyboard Input Provider", menuName = "DSS/Player/Input Providers/KeyboardMouse Provider")]
    public class KeyboardMouseInputProvider : PlayerInputProvider
    {
        [Header("Move")]
        [SerializeField] private string horizontalMoveAxisName = "Horizontal";
        [SerializeField] private string verticalMoveAxisName = "Vertical";

        [Header("Look")]
        [SerializeField] private string horizontalLookAxisName = "Mouse X";
        [SerializeField] private string verticalLookAxisName = "Mouse Y";

        [Header("Jump")]
        [SerializeField] private string jumpButtonName = "Jump";

        public override float GetMoveHorizontal()
        {
            return Input.GetAxis(horizontalMoveAxisName);
        }

        public override float GetMoveVertical()
        {
            return Input.GetAxis(verticalMoveAxisName);
        }


        public override float GetLookHorizontal()
        {
            return Input.GetAxis(horizontalLookAxisName);
        }

        public override float GetLookVertical()
        {
            return Input.GetAxis(verticalLookAxisName);
        }

        public override bool GetJump()
        {
            return Input.GetButtonDown(jumpButtonName);
        }
    }
}
