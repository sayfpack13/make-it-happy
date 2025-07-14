using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private void Start()
    {
 
            this.GetComponent<Dropdown>().value = QualitySettings.GetQualityLevel();


    }
    public void setquality()
    {
            QualitySettings.SetQualityLevel(this.GetComponent<Dropdown>().value) ;

    }
}
