using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockAndUnlock : MonoBehaviour
{

    private void Start()
    {
        LockMouse();
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
