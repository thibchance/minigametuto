using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int life = 3;
    [SerializeField]
    private Text textlifeplayer;
    [SerializeField]
    private Text textlifemonster;
    [SerializeField]
    
    private const string TEXT_LIFE = "Life = ";
    [SerializeField]
    private GameObject[] ennemi;
    // Use this for initialization
    void Start ()
    {
        textlifeplayer.text = TEXT_LIFE + life;
        textlifemonster.text = TEXT_LIFE + life;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(ennemi.Length);
		if (ennemi.Length == 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
	}
    public void PlayerDie()
    {
        life--;

            if (life<=0)
        {
            SceneManager.LoadScene("Gameover");
            
            //SceneManager.LoadScene("StartMenu");
        }
        else
        {
            textlifeplayer.text = TEXT_LIFE + life;
        }
        
    }
    public void lifes()
    {
        life++;
        textlifeplayer.text = TEXT_LIFE + life;
    }

    public void MonsterDie()
    {
       // ennemi.Length =ennemi.Length- 1;
    }

}
