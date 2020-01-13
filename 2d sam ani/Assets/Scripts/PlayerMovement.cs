using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;   // vždy když napíšem controller tak to bude odkaz na to co je v řádku v unity u player movementu

    public Animator animator; // odkazuje na Animator v unity kolonka která je na Playerovi 


    private Rigidbody2D rb;

    public float runSpeed ;
    public float walkSpeed = 40f;
    public float sprintSpeed = 60f;

    

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    



    // Update se obnovuje každou sekundu
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));   // tady říkáme že Speed má mít hodnotu horizontalMove. Ale musíme přidat Mathf.Abs(horizontalMove)
                                                      // Protože když se po ose X pohybujem doleva tak jdem do - ale u hodnoty Speed kterou jsme si nastavili
                                                      // v Animator->Parameters->"+" nejde jít do - tak absolutní hodnota nám to napraví na +

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


        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = sprintSpeed;
        }
        else
            {
            runSpeed = walkSpeed;
            }

               
        

    }


         

}
