using UnityEngine;

namespace DSS.PlayerControllers
{
    // @brief Locks the cursor while the script is "paused", and unlocks it
    // when the script is "unpaused".
    public class CursorController : MonoBehaviour
    {
        [Header("Pause")]
        public bool paused = false;

        void Update()
        {
            if (paused)
            {
                if (Cursor.lockState != CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                }
            }
            else
            {
                if (Cursor.lockState != CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (Cursor.visible)
                {
                    Cursor.visible = false;
                }
            }
        }
    }
}
