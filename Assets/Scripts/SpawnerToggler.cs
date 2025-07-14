using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class SpawnerToggler : MonoBehaviour
{



    public Water2D_Spawner spawner;





 

    public void onclickspwan()
    {
        StartSpawner();

    }

    public void OnMouseDown()
    {
        StartSpawner();
    }


    public void StartSpawner()
    {
        if (spawner.started == false && !spawner.SimulateOnAwake)
        {
            spawner.SimulateOnAwake = true;
            spawner.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
            StartCoroutine(spawner.Start());
            spawner.started = true;
        }
    }
}
