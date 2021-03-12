using UnityEngine;

namespace DSS.PlayerControllers
{
    public abstract class PlayerInputProvider : ScriptableObject
    {
        public abstract float GetMoveHorizontal();
        public abstract float GetMoveVertical();

        public abstract float GetLookHorizontal();
        public abstract float GetLookVertical();

        public abstract bool GetJump();
    }
}
