using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenloaderOut : MonoBehaviour
{

    public GameObject ScreenLoaderOut;


    public float delay;

    void Start()
    {
        ScreenLoaderOut.SetActive(true);
        delay = ScreenLoaderOut.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Invoke("destroyobject", delay);
    }

    void destroyobject()
    {
        Destroy(ScreenLoaderOut);
    }


}
