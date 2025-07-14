using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanScreen : MonoBehaviour
{

    public bool WaterCheck, CreamCheck, IcecreamCheck = false;

    public int WaterCount,CreamCount,IcecreamCount = 0;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GetComponent<CameraAutoMove>().movecameradown)
            Invoke("Check", 1f);


        if(gm.LevLost.activeSelf)
            GetComponent<CameraAutoMove>().movecameradown = false;
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Water" && WaterCheck)
        {
            WaterCount++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (GetComponent<CameraAutoMove>().movecameradown)
        {
            if (other.gameObject.tag == "Water" && WaterCheck)
            {
                WaterCount--;
            }
            else if (other.gameObject.tag == "Cream" && CreamCheck)
            {
                CreamCount--;
            }
            else if (other.gameObject.tag == "IceCream" && IcecreamCheck)
            {
                IcecreamCount--;
            }
            else if(other.gameObject.CompareTag("Scratch") || other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Water Generator") || other.gameObject.CompareTag("Cream Generator") || other.gameObject.CompareTag("IceCream Generator") || other.gameObject.CompareTag("Hot"))
            {
                Destroy(other.gameObject);
            }
        }
    }







    void Check()
    {
        if (WaterCount == 0 && WaterCheck || CreamCount == 0 && CreamCheck || IcecreamCount == 0 && IcecreamCheck)
            lost();
    }


    void lost()
    {
        gm.GetComponent<AudioSource>().clip = GameManager.FindObjectOfType<GameManager>().LostClip;
        gm.GetComponent<AudioSource>().Play();
        gm.LevLost.SetActive(true);
    }
}
