using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField]
    private float force = 2;
    [Header("Jump")]
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private float radiusRaycastJump;
    [SerializeField]
    private LayerMask LayerMaskJump;
    [SerializeField]
    private float forcejump = 2;

   
    


    [Header("Fire gun super sonic lol boum")]

    [SerializeField]
     GameObject bulletPrefab;
    [SerializeField]
     Transform guntransform;
    [SerializeField]
     float bulletVelocity = 2;
    [SerializeField]
    float timetofire = 2;
    private float lasttimefire = 0;

    private Rigidbody2D rigidbody;
    private Transform spawnTransform;
    private GameManager gamemanager;
    private Animator PlayerAnimation;
    private SpriteRenderer render;
    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        spawnTransform = GameObject.Find("Spawn").transform;
       
        gamemanager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        PlayerAnimation.SetFloat("speedX", Mathf.Abs(HorizontalInput));
        PlayerAnimation.SetFloat("VelocityY", rigidbody.velocity.y);
        render.flipX = HorizontalInput < 0;
        Vector2 forceDirection = new Vector2(HorizontalInput, 0);
        forceDirection *= force;
        rigidbody.AddForce(forceDirection);
        bool touchfloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastJump, LayerMaskJump);
        if (Input.GetAxis("Jump") > 0 && touchfloor)
        {
            rigidbody.AddForce(Vector2.up * forcejump, ForceMode2D.Impulse);
            PlayerAnimation.SetTrigger("Jump");
        }
        else
        {
            PlayerAnimation.SetBool("IsGrounded", touchfloor);
        }
        
        if (Input.GetAxis("Fire1") > 0)
        {
            Fire();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Limit")
        {
            transform.position = spawnTransform.position;
            //gamemanager.PlayerDie();
            
        }
        if (collision.tag == "Heart")
        {
            gamemanager.lifes();
            Destroy(collision.gameObject);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HitEnnemi")
        {
           
            Destroy(collision.gameObject);
            gamemanager.PlayerDie();
        }
    }

    
    private void Fire()
    {
        if (Time.realtimeSinceStartup - lasttimefire > timetofire)
        {

            GameObject bullet = Instantiate(bulletPrefab, guntransform.position, guntransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = guntransform.right * bulletVelocity;
            Destroy(bullet, 5);
            lasttimefire = Time.realtimeSinceStartup;
        }
    }
}
