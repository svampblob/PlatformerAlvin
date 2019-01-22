using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{   // dessa floats sätter ett numer på hur snabb och hur stark kraft man hoppar med. 
    public float moveSpeed = 30f;
    public float jumpSpeed = 16f;
    // Detta gör så att scriptet "GroundChecker" aktiveras och hjäpler "PlayerMovment" så att man behöver vara på marken för att kunna hoppa.  
    public GroundChecker groundCheck;
    // Private gör så att man inte kan ändra det i unity.
    private Rigidbody2D rbody;
    // idena så säger den till att man har tio stycken av Health. 
    public int Health = 10;
    
    
    
    // Use this for initialization
    void Start()
    {
        
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);
        // Detta gör så att när man trycker ner i denna situaton så är det mellan slag. 
        if(Input.GetButtonDown("Jump"))
        { // Sedan användes "isGrounded" som gör så att man kan bara göra dett medans karaktären rör marken. 
            if (groundCheck.isGrounded == true)
            {
                rbody.velocity = new Vector2(rbody.velocity.x,jumpSpeed);
            }
        }
    }
    //I void hurt så finns det två saker som händer. 
    void hurt()
    {
        // första är den hära "Health --;" den säger till att våran health variabel kommer minska med ett varje, gång som "else hurt();".
        Health --;
        //Här står det att när Health är mindre än 0 så kommer..
        if (Health <= 0)
            //Att denna sak kommer att ladda nivån som scriptet är på eller "DÖ". 
            Application.LoadLevel(Application.loadedLevel);
    }
    //"void OnCollisionEnter2D(Collision2D collision)"säger att om en collider collidar med en annan som fienden och spelaren så kommer hela den nedre delen börja.
    private void OnCollisionEnter2D(Collision2D collision)
    {//Och 
        Enemymovment enemy = collision.collider.GetComponent<Enemymovment>();
        if (enemy != null)
        {//foreach är en loop typ som gör så att man kan hoppa/attakera fienden flera gånger en efter en.
            foreach (ContactPoint2D point in collision.contacts)
            {//så här inne står det bara att om man rör fienden så kommer ...
                Debug.Log(point.normal);
                // en röd linja dycka upp och den är bara där för att visa mig när spelaren och fienden rör varandra. 
                Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                // här står det om den "normala positionen" eller vi/ vår position rör den så kommer den dö.
                if (point.normal.y >= 0.9f)
                {//sedan så står det att när det händer så kommer vi flygga upp lite efteråt.
                    Vector2 velocity = rbody.velocity;
                    velocity.y = jumpSpeed;
                    rbody.velocity = velocity;
                    enemy.Hurt();
                }
                else
                {// sedan så står det att om man missar så kommer man att aktivera hurt scripten från nummer 42.
                    hurt();
                }



            }

        }
    }


















}
