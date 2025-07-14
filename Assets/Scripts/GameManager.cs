using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
/// <summary>
/// Happy Glass 
/// Credit: Satyam Parkhi
/// Email: satyamparkhi@gmail.com
/// Facebook : https://www.facebook.com/satyamparkhi
/// Instagram : https://www.instagram.com/satyamparkhi/
/// Whatsapp : +91 7050225661
/// </summary>
public class GameManager : MonoBehaviour
{


    public bool BossLevel = false;
    GameObject cursor;


    public Material lineMaterial;
    public Slider PenCapacity;
    public Text PenPercent;
    [HideInInspector]


    public Image Star1;
    public Image Star2;
    public Image Star3;
    public GameObject LevComp;
    public GameObject LevLost;
    public AudioClip WinClip;
    public AudioClip LostClip;


    private GameObject[] Obs;
    private List<GameObject> listLine = new List<GameObject>();
    private List<Vector2> listPoint = new List<Vector2>();

    private GameObject currentColliderObject;



    private Vector3 LastMosPos;
    private BoxCollider2D currentBoxCollider2D;




    void Start()
    {
        if (GameObject.FindGameObjectWithTag("ScratchTerrain")!=null)
        cursor = GameObject.FindGameObjectWithTag("cursors").transform.GetChild(0).gameObject;
        else
            cursor = GameObject.FindGameObjectWithTag("cursors").transform.GetChild(1).gameObject;





  
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && PenCapacity.value > 0.01f)
        {

            if (LastMosPos != Camera.main.ScreenToWorldPoint(Input.mousePosition))
            {
                float dist = Vector3.Distance(LastMosPos, Camera.main.ScreenToWorldPoint(Input.mousePosition));


                if(cursor.activeSelf)
                {
                if(!BossLevel)
                    {
                        PenCapacity.value = PenCapacity.value - dist / 75;
                        PenPercent.text = Mathf.FloorToInt(PenCapacity.value * 100).ToString() + " %";

                    }
                else
                    {
                        PenCapacity.value = PenCapacity.value - dist / 90;
                        PenPercent.text = Mathf.FloorToInt(PenCapacity.value * 100).ToString() + " %";

                    }
                    if (Mathf.FloorToInt(PenCapacity.value * 100) < 75)
                {
                    Star3.gameObject.SetActive(false);
                }
                if (Mathf.FloorToInt(PenCapacity.value * 100) < 50)
                {
                    Star2.gameObject.SetActive(false);
                }
                if (Mathf.FloorToInt(PenCapacity.value * 100) < 25)
                {
                    Star1.gameObject.SetActive(false);
                }
                }
            }


            cursor.SetActive(true);
            cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);






        }
        else
            cursor.SetActive(false);


        LastMosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

 
  


}

