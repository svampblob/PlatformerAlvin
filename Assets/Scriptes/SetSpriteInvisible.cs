using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteInvisible : MonoBehaviour {
    //Allt som detta script gör är att när spelet börjar, så kommer saken som man har laggt scriptet på att bli onsynligt.  
	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().enabled = false;

	}
	
}
