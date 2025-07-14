using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Happy Glass 
/// Credit: Satyam Parkhi
/// Email: satyamparkhi@gmail.com
/// Facebook : https://www.facebook.com/satyamparkhi
/// Instagram : https://www.instagram.com/satyamparkhi/
/// Whatsapp : +91 7050225661
/// </summary>
[ExecuteInEditMode]
public class LockedLevels : MonoBehaviour {


    public GameObject ScreenLoaderIn;

    void Awake()
    {
        transform.GetChild(1).localScale = Vector3.one;
      
        for (int i = 0; i < 101; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), 1);
        }
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }
        UnLockLevels();
        
    }
    void Update()
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().text = transform.name;
        transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = 75;
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void UnLockLevels()
    {

        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1) ;
            GetComponent<Button>().interactable = true;
            if (PlayerPrefs.GetInt("Star" + gameObject.name) == 3)
            {
                for (int i = 0; i < transform.GetChild(1).childCount; i++)
                {
                    transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Star" + gameObject.name) == 2)
            {
                for (int i = 0; i < transform.GetChild(1).childCount-1; i++)
                {
                    transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Star" + gameObject.name) == 1)
            {
                transform.GetChild(1).GetChild(0).gameObject.SetActive(true);

            }
            else if (PlayerPrefs.GetInt("Star" + gameObject.name) == 0)
            {
                for (int i = 0; i < transform.GetChild(1).childCount; i++)
                {
                    transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            GetComponent<Button>().interactable = false;
            transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1, 1, 1, .5f);
        }
    }
    public void LevelMenu()
    {
        screenloaderin();
        StartCoroutine(loadscene(transform.name));
    }



    void screenloaderin()
    {
        if(ScreenLoaderIn.activeSelf==false)
        ScreenLoaderIn.SetActive(true);
    }

    IEnumerator loadscene(string scenename)
    {
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

