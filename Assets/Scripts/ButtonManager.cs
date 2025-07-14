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
public class ButtonManager : MonoBehaviour {

    public GameObject ScreenLoaderIn;


    public void Reload()
    {
        screenloaderin(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        screenloaderin("MainMenu");
    }


    public void Settings()
    {
        screenloaderin("SettingsMenu");
    }


    int contc;
    public void Play()
    {
        //if (contc == 0)
        //{
        //    transform.parent.GetChild(2).gameObject.SetActive(true);
        //    contc++;
        //}
        //else
        //{
        screenloaderin("LevelMenu");
        //}
    }

    public void NextLevel()
    {

        screenloaderin(NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Close()
    {
        transform.parent.gameObject.SetActive(false);
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




    private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }


    void screenloaderin(string scenename)
    {
        if (!ScreenLoaderIn.activeSelf)
        {
            ScreenLoaderIn.SetActive(true);
            StartCoroutine(loadscene(scenename));
        }
    }
}
