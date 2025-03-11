using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRB2d;

    public Transform groundCheck;

    public bool isGround = false;

    public float speed;

    public float touchRun = 0.0f;

    public bool facingRight = true;

    //Pulo
    public bool jump = false;
    public int numberJump = 0, maximoJump = 2;
    public float jumpForce;

    private ControllerGame controleGame;

    public AudioSource fxGame;
    public AudioClip fxPulo;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRB2d = GetComponent<Rigidbody2D>();

        controleGame = FindObjectOfType(typeof(ControllerGame)) as ControllerGame;
    }


    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnimator.SetBool("IsGrounded", isGround );

        touchRun = Input.GetAxisRaw("Horizontal");

        SetaMovimentos();

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void MovePlayer (float movimentoH)
    {
        playerRB2d.velocity = new Vector2(movimentoH * speed, playerRB2d.velocity.y);

        if(movimentoH < 0 && facingRight == true || (movimentoH > 0 && !facingRight))
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(touchRun);

        if (jump) 
        {
            JumpPlayer();
        }
    }

    void JumpPlayer()
    {
        if(isGround)
        {
            numberJump = 0;
        }

        if (isGround || numberJump < maximoJump) // true
        {
            playerRB2d.velocity = new Vector2(0f, jumpForce);
            isGround = false;
            numberJump++;

            fxGame.PlayOneShot(fxPulo);
        }
        jump = false;
    }

    void Flip ()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    void SetaMovimentos()
    {
        playerAnimator.SetBool("Walk", playerRB2d.velocity.x != 0 && isGround); //true
        playerAnimator.SetBool("Jump", !isGround);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "coletaveis":
                controleGame.Pontuacao(1);
                
                Destroy(collision.gameObject);
                break;


            case "inimigo":

                //Adiciona força ao pulo
                Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, 600));
                
                //Destroi inimigo
                Destroy(collision.gameObject);


                break;
        }
    }

}
