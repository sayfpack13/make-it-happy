using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoMoveToggler : MonoBehaviour
{

    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.GetComponent<CameraAutoMove>().MoveDown();
    }
}
