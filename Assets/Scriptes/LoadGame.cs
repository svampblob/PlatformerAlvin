using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {
// Public int minimuScoreNedded säger till att man behöver en vis mängd av poeng för att saken som han har detta script (flagan) så kommer en valde scene a ladda. 
    public int minimuScoreNedded = 0;
    public string sceneToLoad = "Platformer";
    // vad som händer här är att om spelaren går igenom pengarna så kommer peng scriptet aktiveras och sedan kommer minimum scoret minska. 
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag == "Player" && Coin.score >= minimuScoreNedded) 
        {//Här står det att man kommer behöva inga pengar för att lada nästa nivå. 
            Coin.Score = 0;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
