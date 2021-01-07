using UnityEngine;

namespace DSS.FirstPersonController
{
    [RequireComponent(typeof(FirstPersonController))]
    public class CursorController : MonoBehaviour
    {
        FirstPersonController player;

        void Awake()
        {
            player = GetComponent<FirstPersonController>();
        }

        void Update()
        {
            if (player.paused)
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
