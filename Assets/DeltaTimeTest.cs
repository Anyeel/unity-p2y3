using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class DeltaTimeTest : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] int framesPerNumber;
    private int count = 0;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        count++;
        if (count == framesPerNumber) 
        {
            number++;
            textUI.text = number.ToString();
            count= 0;
        }
    }
}

//Comprobar si los fps han alcanzado framesPerNumber y sumar 1 a count.