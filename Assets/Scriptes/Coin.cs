using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{// Static gör så att det här objectet inte kan ändras utanför detta script.
    public static int score;

    public int amount = 1;
    //Detta är hur snabbt den ska spina.
    private float spinspeed = 180;

    public static object Score { get; internal set; }
    
    private void Update()
    {// Här står det att pengarna kommer att rotera via Z axeln.
        transform.Rotate(0, spinspeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
 //Här står det att om "spelaren" kommer i kontakt med en peng så kommer man få ett poäng och pengen kommer att förstörars.  
       if(Collision.tag == "Player")
        { 
            Coin.score += amount;
            Destroy(gameObject);
        }

    }
}
