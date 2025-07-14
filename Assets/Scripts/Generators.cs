using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;



public class Generators : MonoBehaviour
{






    public float Water_AlphaCutOff;
    public float Water_AlphaStroke;
    public float Water_TrailStartSize;
    public float Water_TrailEndSize;
    public float Water_TrailDelay;
    public float Water_size;
    public float Water_DelayBetweenParticles;


    public float Cream_AlphaCutOff;
    public float Cream_AlphaStroke;
    public float Cream_TrailStartSize;
    public float Cream_TrailEndSize;
    public float Cream_TrailDelay;
    public float Cream_size;
    public float Cream_DelayBetweenParticles;


    public float IceCream_AlphaCutOff;
    public float IceCream_AlphaStroke;
    public float IceCream_TrailStartSize;
    public float IceCream_TrailEndSize;
    public float IceCream_TrailDelay;
    public float IceCream_size;
    public float IceCream_DelayBetweenParticles;



    public float Hot_AlphaCutOff;
    public float Hot_AlphaStroke;
    public float Hot_TrailStartSize;
    public float Hot_TrailEndSize;
    public float Hot_TrailDelay;
    public float Hot_size;
    public float Hot_DelayBetweenParticles;




    public GameObject ScreenLoaderOut;
    public GameObject GetDelay;

    float delay;
    int a;




    void Start()
    {
        delay = GetDelay.GetComponent<ScreenloaderOut>().delay;
        Invoke("adjust", delay / 2);
    }

    void adjust()
    {
        Color mycolor = new Color();
        for (a = 0; a < this.transform.childCount; a++)
        {
            if (this.transform.GetChild(a).CompareTag("Water Generator"))
            {


                ColorUtility.TryParseHtmlString("#509FE0", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor);
                ColorUtility.TryParseHtmlString("#989797", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TintColor);
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor.a = 200f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaCutOff = Water_AlphaCutOff;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaStroke = Water_AlphaStroke;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().Sorting = 0;


                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailStartSize = Water_TrailStartSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailEndSize = Water_TrailEndSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailDelay = Water_TrailDelay;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().size = Water_size;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LifeTime = 0f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().DelayBetweenParticles = Water_DelayBetweenParticles;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().ColliderSize = 1.2f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LinearDrag = 2f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AngularDrag = 0f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().GravityScale = 2f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FreezeRotation = false;

            }


            else if (this.transform.GetChild(a).CompareTag("Cream Generator"))
            {
                ColorUtility.TryParseHtmlString("#DDB33C", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor);
                ColorUtility.TryParseHtmlString("#989797", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TintColor);
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor.a = 200f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaCutOff = Cream_AlphaCutOff;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaStroke = Cream_AlphaStroke;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().Sorting = 0;


                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailStartSize = Cream_TrailStartSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailEndSize = Cream_TrailEndSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailDelay = Cream_TrailDelay;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().size = Cream_size;

                //this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LifeTime = 0f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().DelayBetweenParticles = Cream_DelayBetweenParticles;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().ColliderSize = 1.5f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LinearDrag = 3f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AngularDrag = 30f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().GravityScale = 2f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FreezeRotation = false;
            }


            else if (this.transform.GetChild(a).CompareTag("IceCream Generator"))
            {
                ColorUtility.TryParseHtmlString("#F8F8F8", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor);
                ColorUtility.TryParseHtmlString("#989797", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TintColor);
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor.a = 200f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaCutOff = IceCream_AlphaCutOff;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaStroke = IceCream_AlphaStroke;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().Sorting = 0;



                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailStartSize = IceCream_TrailStartSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailEndSize = IceCream_TrailEndSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailDelay = IceCream_TrailDelay;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().size = IceCream_size;

                //this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LifeTime = 0f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().DelayBetweenParticles = IceCream_DelayBetweenParticles;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().ColliderSize = 1.5f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LinearDrag = 3f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AngularDrag = 20f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().GravityScale = 2f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FreezeRotation = true;
            }
            else if (this.transform.GetChild(a).CompareTag("Hot"))
            {
                ColorUtility.TryParseHtmlString("#E04025", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor);
                ColorUtility.TryParseHtmlString("#989797", out this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TintColor);
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FillColor.a = 200f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaCutOff = IceCream_AlphaCutOff;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AlphaStroke = IceCream_AlphaStroke;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().Sorting = 0;



                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailStartSize = IceCream_TrailStartSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailEndSize = IceCream_TrailEndSize;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().TrailDelay = IceCream_TrailDelay;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().size = IceCream_size;

                //this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LifeTime = 0f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().DelayBetweenParticles = IceCream_DelayBetweenParticles;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().ColliderSize = 1.5f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().LinearDrag = 3f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().AngularDrag = 30f;
                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().GravityScale = 2f;

                this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().FreezeRotation = true;

            }




            this.transform.GetChild(a).gameObject.GetComponent<Water2D_Spawner>().Restore();
        }
    }


}
