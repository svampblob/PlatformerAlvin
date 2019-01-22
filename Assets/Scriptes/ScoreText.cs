using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class ScoreText : MonoBehaviour
{
//Detta är en reference till text componenten. 
private TextMeshProUGUI text;
    
    // Use this for initialization
    private void Start()
    {//så drar man Text variablen till getcomponent för att sedan hitta componenten för detta object.
       // GetComponent<Text>();  
     text = GetComponent<TextMeshProUGUI>();
    }
  // Update is called once per frame 
    void Update()
    {// detta gör så att i texten så kommer dett alltid stå score medans man när man rör en krona så läggs det till ett poäng. 
     text.text = string.Format("{0:000}", Coin.score);
    }
   
}
