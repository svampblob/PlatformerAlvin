
using UnityEngine;

public class RouteScritpe : MonoBehaviour {
    [SerializeField]

    private Transform[] controlPoint;

    private Vector2 gizmosPositioin;
    //Hela detta Scripte är nästa bara en hel kalkulator eftersom min route är gjorde av bezier curves som har en ekvation som ser typ ut som..
    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {//det här.
            gizmosPositioin = Mathf.Pow(1 - t, 3) * controlPoint[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoint[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoint[2].position +
                Mathf.Pow(t, 3) * controlPoint[3].position;

            Gizmos.DrawSphere(gizmosPositioin, 0.25f);
        }

        //Det här gör så att alla points är konectade och att man kan ändra dem. 
        //detta händer tack vare DrawLine.
        Gizmos.DrawLine(new Vector2(controlPoint[0].position.x, controlPoint[0].position.y), new Vector2(controlPoint[1].position.x,
            controlPoint[1].position.y));

        Gizmos.DrawLine(new Vector2(controlPoint[2].position.x, controlPoint[2].position.y), new Vector2(controlPoint[3].position.x,
            controlPoint[3].position.y));
    }

    
}
