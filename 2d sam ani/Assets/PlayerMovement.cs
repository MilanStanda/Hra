using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;   // vždy když napíšem controller tak to bude odkaz na to co je v řádku v unity u player movementu

    public float runSpeed = 30f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    

    // Update se obnovuje každou sekundu
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
            else if (Input.GetButtonUp("Crouch"))
             {
                 crouch = false;
             }
              
    }

    void FixedUpdate()
    {
        //pohyb hráče
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);   
        jump = false;    //musí být protože jinak bychom skákali do nekonečna
    }







}
