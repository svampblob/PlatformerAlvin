using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovment : MonoBehaviour
{
    public float Speed = 2;

    private Rigidbody2D rbody;

    public bool isleft = true;
   


    // Use this for initialization
    void Start()
    {
        //denna line, kallar på rigidbodys för alla fiender. 
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         // Det här gör så att den ska gå ett hål tills den blir falsk.  
        if (isleft == true)
        {

            rbody.velocity = -(Vector2)transform.right * Speed;
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else// Då så kommer den att vända sig och gå åt andra hållet. 
        {
            rbody.velocity= -(Vector2)transform.right * -Speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    // "OnTriggerEnter2D" gör så att när något som har en Trigger på sig och rör något annat (fienden) så kommer  
    void OnTriggerEnter2D(Collider2D collision)
    { //Detta gör så att när råttan kommer i mot en unsynlig väg, så aktiveras koden över som gör att råttan vänder sig om.   
        if (collision.tag == "invisiblewall")
        {
            isleft = !isleft;

        }
    }
    // Här står det att när scriptet från PlayerMovment aktiveras...
    public void Hurt()
    {
        // så kommer fienden eller den här saken förstöras.
        Destroy(this.gameObject);
    }



}
