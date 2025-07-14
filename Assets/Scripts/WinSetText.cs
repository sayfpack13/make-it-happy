using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSetText : MonoBehaviour
{
    string settext;
    int randomnumber;
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = Random.Range(1, 4);

        if (randomnumber == 1)
            settext = "You Win !!";
        if (randomnumber == 2)
            settext = "You Did IT !!";
        if (randomnumber == 3)
            settext = "Welldone !!";

        GetComponent<Text>().text = settext;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
