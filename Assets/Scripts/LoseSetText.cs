using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseSetText : MonoBehaviour
{
    string settext;
    int randomnumber;
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = Random.Range(1, 4);

        if (randomnumber == 1)
            settext = "Better Luck\nNext Time !!";
        if (randomnumber == 2)
            settext = "Game Over !!";
        if (randomnumber == 3)
            settext = "Try Again !!";

        GetComponent<Text>().text = settext;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
