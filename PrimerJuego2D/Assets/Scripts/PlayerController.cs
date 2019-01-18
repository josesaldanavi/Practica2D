using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject jugador;
    public float speed;
    public float forceJump;
    public bool isGrounded;
    public float radius;
    public float maxForce=5f;
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
        float limitForce = Mathf.Clamp(rgbd2D.velocity.x, -maxForce, maxForce);
        rgbd2D.velocity = new Vector2(limitForce, rgbd2D.velocity.y);
        player.SetFloat("Walk", Mathf.Abs(horizontal));
      
        if (horizontal < 0)
        {
            spritePlayer.flipX = true;
        }
        if (horizontal > 0)
        {
            spritePlayer.flipX = false;
        }
        Jump(rgbd2D);
        Attack();
    }

    void Jump(Rigidbody2D rbd2)
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rbd2.velocity = new Vector2(rbd2.velocity.x,0);
            player.SetBool("Jump", true);
            rgbd2D.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            
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
