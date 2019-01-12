using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject jugador;
    public float speed;
    public float forceJump;
    public bool isGrounded;
    public float radius;
    public Transform checkGround;
    public LayerMask whatIsGround;
    Rigidbody2D rgbd2D;
    Animator player;
    SpriteRenderer spritePlayer;
	// Use this for initialization
	void Start ()
    {
        jugador = GameObject.Find("Jugador");
        rgbd2D = jugador.GetComponent<Rigidbody2D>();
        player = jugador.GetComponent<Animator>();
        spritePlayer = jugador.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
 
        

	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log(horizontal);
        Vector2 v_2 = new Vector2(horizontal, 0);
        rgbd2D.velocity = v_2 * speed * Time.deltaTime;
        player.SetFloat("Walk", Mathf.Abs(horizontal));
        if (horizontal < 0)
        {
            spritePlayer.flipX = true;
        }
        if (horizontal > 0)
        {
            spritePlayer.flipX = false;
        }
        isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rgbd2D.velocity = Vector2.up * forceJump;
            player.SetBool("Jump", true);
        }
    }

}
