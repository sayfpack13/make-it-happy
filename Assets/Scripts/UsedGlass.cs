using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Water2D;

public class UsedGlass : MonoBehaviour
{


 
    

    GameManager gm;


    GameObject glass;


    int Star;




    private bool win, lose, show_next = false;

    public int HappyCount = 0, GlassCount=0;
    int a;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        GlassCount = this.transform.GetChild(0).transform.childCount;

  
    }



    // Update is called once per frame
    void Update()
    {
        if(win==false)
        {
            HappyCount = 0;
            for (a=0;a< GlassCount; a++)
            {
                glass = this.transform.GetChild(0).transform.GetChild(a).transform.GetChild(1).gameObject;

                if (glass.CompareTag("WaterGlass"))
                {
                    if (glass.GetComponent<Water_Glass>().happy)
                        HappyCount++;
                }
                else if (glass.CompareTag("CreamGlass"))
                {
                    if (glass.GetComponent<Cream_Glass>().happy)
                        HappyCount++;
                }
                else if (glass.CompareTag("IceCreamGlass"))
                {
                    if (glass.GetComponent<IceCream_Glass>().happy)
                        HappyCount++;
                }


            }


            if (HappyCount == GlassCount)
                win = true;


        }

        if (win && show_next==false && !lose)
        {
            show_next = true;

            Invoke("Win", 2);
        }





        if(lose==false)
        {
            for(a=0;a<GlassCount;a++)
            {
                glass = this.transform.GetChild(0).transform.GetChild(a).transform.GetChild(1).gameObject;
                if (glass.CompareTag("WaterGlass"))
                {
                    if (glass.GetComponent<Water_Glass>().sad)
                        lose = true;
                }
                else if (glass.CompareTag("CreamGlass"))
                {
                    if (glass.GetComponent<Cream_Glass>().sad)
                        lose = true;
                }
                else if (glass.CompareTag("IceCreamGlass"))
                {
                    if (glass.GetComponent<IceCream_Glass>().sad)
                        lose = true;
                }
            }

        }

        if (lose && show_next == false && !win)
        {
            show_next = true;

            Invoke("Lose", 2);
        }

    }




    void Lose()
    {
        gm.GetComponent<AudioSource>().clip = GameManager.FindObjectOfType<GameManager>().LostClip;
        gm.GetComponent<AudioSource>().Play();
        gm.LevLost.SetActive(true);
    }


    void Win()
    {
        for (int i = 0; i < Camera.main.transform.childCount; i++)
        {
            if (Camera.main.transform.GetChild(i).GetComponent<ParticleSystem>() != null)
            {
                Camera.main.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
            }
        }

        if (Mathf.FloorToInt(gm.PenCapacity.value * 100) > 75)
        {
            Star = 3;
        }
        else if (Mathf.FloorToInt(gm.PenCapacity.value * 100) > 50)
        {
            Star = 2;
        }
        else if (Mathf.FloorToInt(gm.PenCapacity.value * 100) > 25)
        {
            Star = 1;
        }

        PlayerPrefs.SetInt((SceneManager.GetActiveScene().buildIndex).ToString(), 1);
        PlayerPrefs.SetInt("Star" + SceneManager.GetActiveScene().name, Star);
        gm.LevComp.SetActive(true);
        if (Star > 2)
        {
            gm.LevComp.transform.GetChild(0).gameObject.SetActive(true);
            gm.LevComp.transform.GetChild(1).gameObject.SetActive(true);
            gm.LevComp.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Star > 1)
        {
            gm.LevComp.transform.GetChild(0).gameObject.SetActive(true);
            gm.LevComp.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Star > 0)
        {
            gm.LevComp.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
