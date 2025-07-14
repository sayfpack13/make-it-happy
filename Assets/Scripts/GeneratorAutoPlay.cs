using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class GeneratorAutoPlay : MonoBehaviour
{
    public GameObject Generator;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            
            if (Generator.GetComponent<Water2D_Spawner>().started == false && !Generator.GetComponent<Water2D_Spawner>().SimulateOnAwake)
            {
                Generator.GetComponent<Water2D_Spawner>().SimulateOnAwake = true;
                //Generator.GetComponent<Water2D_Spawner>().transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                StartCoroutine(Generator.GetComponent<Water2D_Spawner>().Start());
                Generator.GetComponent<Water2D_Spawner>().started = true;
            }
        }
    }


}
