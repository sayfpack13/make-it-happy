using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Happy Glass 
/// Credit: Satyam Parkhi
/// Email: satyamparkhi@gmail.com
/// Facebook : https://www.facebook.com/satyamparkhi
/// Instagram : https://www.instagram.com/satyamparkhi/
/// Whatsapp : +91 7050225661
/// </summary>
public class Water_Glass : MonoBehaviour
{

    int trigCont;

    public Sprite NormalGlass;
    public Sprite SurpriseGlass;
    public Sprite HappyGlass;
    public Sprite SadGlass;



    int Star;

    private int InGlassCountToWin = 10;


    public bool happy = false,sad=false;
    


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {





            if (trigCont == 0)
            {
                transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite = SurpriseGlass;

            }
            col.gameObject.tag = "InGlassWater";
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = .3f;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = col.gameObject.GetComponent<Rigidbody2D>().velocity / 4;
            trigCont++;

            if (trigCont > InGlassCountToWin-1)
            {

                if (trigCont == InGlassCountToWin && !sad)
                {

                    transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite = HappyGlass;
                    GameManager.FindObjectOfType<GameManager>().GetComponent<AudioSource>().clip = GameManager.FindObjectOfType<GameManager>().WinClip;
                    GameManager.FindObjectOfType<GameManager>().GetComponent<AudioSource>().Play();
                    happy = true;
                    

                    CancelInvoke("Check");

                }
            }
            else
            {
                CancelInvoke("Check");
                Invoke("Check", 30);
            }

        }
        else if (!col.gameObject.CompareTag("cursor") && !col.gameObject.CompareTag("InGlassWater") && !col.gameObject.CompareTag("GlassParent") && !col.gameObject.CompareTag("WaterGlass") && !col.gameObject.CompareTag("MainCamera"))
        {
            
            CancelInvoke("Check");
            Check();
        }
    }
    void Check()
    {
        if (trigCont < InGlassCountToWin)
        {
            transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite = SadGlass;
            sad = true;
        }
            
    }



}
