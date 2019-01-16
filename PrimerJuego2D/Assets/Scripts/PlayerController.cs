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

    [Header("Attack")]
    public Transform attackPos;
    public float Range;
    public float damage;
    public LayerMask whatIsEnemy;

    
	// Use this for initialization
	void Start ()
    {
        jugador = GameObject.Find("Jugador");
        rgbd2D = jugador.GetComponent<Rigidbody2D>();
        player = jugador.GetComponent<Animator>();
        spritePlayer = jugador.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame

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
        Jump();
        Attack();
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rgbd2D.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            player.SetBool("Jump", true);
        }
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.X))
        {
            /*Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, Range, whatIsEnemy);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>();
            }*/
            player.SetBool("Attack",true);
        }
        else
        {
            player.SetBool("Attack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGround.position, radius);
    }

}
