using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoMove : MonoBehaviour
{

    public GameObject StopObject;

    public bool movecameradown = false;
    float verticalSpeed = 0.3f;

    public void MoveDown()
    {
        movecameradown = true;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.ReferenceEquals(other.gameObject, StopObject.gameObject))
            movecameradown = false;
    }



    void Update()
    {
        if(movecameradown)
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
    }
}
