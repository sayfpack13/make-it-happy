using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid_Vapour : MonoBehaviour
{
 
  


    void OnCollisionEnter2D(Collision2D other)
    {
        if(this.transform.tag=="Water" || this.transform.tag == "Cream" || this.transform.tag == "IceCream" || this.transform.tag == "InGlassWater" || this.transform.tag == "InGlassCream" || this.transform.tag == "InGlassIceCream")
                if (other.transform.tag == "Hot")
        {

            //GetComponent<AudioSource>().Play();
            this.transform.tag = "Gas";
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
            GetComponent<Rigidbody2D>().gravityScale = -0.5f;
            
 


        }
    }

}
