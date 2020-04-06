using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Singleton
    public static playerController Instance;

    //Public

    public float vida;
    public string nombre;
    public float force;
    public float jumpForce;
    public GameObject groundCheck;
    
    public Transform Door;

    //private 
    private float h, v;
    private bool isCorriendo;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isOnFloor;
    private Animator anim;
    internal bool Stunned;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Instance = this; //singleton
    }

    void Update()
    {
        //...Monitoreo de Axis...

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //...Seccion de correr...
        if (Input.GetButton("Run"))
        {
            isCorriendo = true;
        }
        else
        {
            isCorriendo = false;
        }

        //...Seccion de salto...

        isOnFloor = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Floor"));

        
    }

    void FixedUpdate()
    {
        //...Si no está stunneado...

        if (!Stunned)
        {
            //...horizontal...
            if (h != 0)
            {
                //...Gira en su eje X a la izquierda o derecha...
                transform.localScale = new Vector3(Mathf.Sign(h) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

                //...movimiento del personaje caminando eje X...
                if (!isCorriendo)
                {
                    rb.velocity = new Vector2(h * force, rb.velocity.y);

                    //..si esta en el suelo y no saltando...
                    if (isOnFloor)
                    {
                        anim.Play("run");
                    }
                }

                //...movimiento del personaje corriendo...
                else if (isCorriendo)
                {
                    rb.velocity = new Vector2((h * force) + ((h * force) * 0.5f), rb.velocity.y);

                    //..si esta en el suelo y no saltando...

                    if (isOnFloor)
                    {
                        anim.Play("run");
                    }
                }
            }
        }

        //...Si está stunneado...
        else
        {
            anim.Play("dead");
        }

        //...Si no se esta presionando ningun boton...

        if (h == 0 && isOnFloor && !Stunned)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            anim.Play("idle");
        }

        //...seccion de salto...

        if (Input.GetButton("Jump") && isOnFloor && !Stunned)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.Play("jump");
        }

        if (!isOnFloor && h != 0)
        {
            anim.Play("jump");

        }

        if (!isOnFloor && rb.velocity.y < -32f && !Stunned)
        {
            PlayerState.StuntPlayer(gameObject,true);
            StartCoroutine(QuitStunt());
        }
    }

    IEnumerator QuitStunt()
    {
        yield return new WaitForSeconds(3f);
        PlayerState.StuntPlayer(gameObject, false);


    }

}
