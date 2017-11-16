using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnnemiController : MonoBehaviour {

    [SerializeField]
    private Transform[] gunTransformList;
    [SerializeField]
    private float timetofire = 2;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity = 10;
    private GameManager gamemanager;

    private int life = 3;
    private Animator ennemianimation;
   
    private GameObject[] ennemi = {};
     
     int timeflash = 5;
    // Use this for initialization

    void Start ()
    {
        ennemianimation = GetComponent<Animator>();
        StartCoroutine(fire());

        gamemanager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ennemianimation.SetTrigger("Attack");
	}
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            
            Destroy(collision.gameObject);
            timeflash = timeflash + 2;
           
            StartCoroutine(Flash());
            life--;
            

                if (life == 0)
                {
                    Destroy(this.gameObject);
               // gamemanager.MonsterDie();

            }



        }
        
    }
   private IEnumerator Flash()
    {
        for(int i = 0; i < timeflash; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.1f);
            //GetComponent<Spr>
        }
    }
    private IEnumerator fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(timetofire);
            foreach (Transform t in gunTransformList)
            {
                GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
                Destroy(bullet, 5);
            }

        }
    }
   
}
