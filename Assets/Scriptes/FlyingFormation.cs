using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFormation : MonoBehaviour
{
    [SerializeField]

    private Transform[] routes;

    private int flyingRoute;

    private float tParam;

    private Vector2 Beesition;

    private float Speedmodifyer;

    private bool CoroutineAllowed;

	// Use this for initialization
	void Start ()
    {
        flyingRoute = 0;
        tParam = 0f;
        Speedmodifyer = 0.8f;
        CoroutineAllowed = true;
	}

	
	// Update is called once per frame
	void Update ()
    {//denna säger att om korutin är till låten så kommer routen att börja . 
        if (CoroutineAllowed)
            StartCoroutine(GoByTheRoute(flyingRoute));
	}


    //detta är basiclly säger att alla routes kommer att vector2 och vart dem är.  
    private IEnumerator GoByTheRoute(int RouteNumber)
    {
        CoroutineAllowed = false;

        Vector2 p0 = routes[RouteNumber].GetChild(0).position;
        Vector2 p1 = routes[RouteNumber].GetChild(1).position;
        Vector2 p2 = routes[RouteNumber].GetChild(2).position;
        Vector2 p3 = routes[RouteNumber].GetChild(3).position;
        //Här säger det att den kommer åka mellan ala olika points 
        while(tParam < 1)
        {
            tParam += Time.deltaTime * Speedmodifyer;

            Beesition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                 Mathf.Pow(tParam, 3) * p3;

            transform.position = Beesition;
            yield return new WaitForEndOfFrame();
        }
        //Där säger bara 
        tParam = 0f;
        flyingRoute += 1;
        //Här säger den till att när den kommer till nol så kommer den gå tillbaka.
        if (flyingRoute > routes.Length - 1);
        flyingRoute = 0;

        CoroutineAllowed = true;


        
    }














}
