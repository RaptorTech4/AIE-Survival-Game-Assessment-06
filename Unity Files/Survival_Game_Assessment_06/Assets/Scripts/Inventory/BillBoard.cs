using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Camera cameraMain;
    private void LateUpdate()
    {
        transform.forward = cameraMain.transform.forward;
    }
}
