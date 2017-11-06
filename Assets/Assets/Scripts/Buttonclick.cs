using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttonclick : MonoBehaviour
{
    [SerializeField]
    private Button buttonclick;
	// Use this for initialization
	void Start ()
    {
        Button btn = buttonclick.GetComponent<Button>();
        btn.onClick.AddListener(loadclick);
	}
	void loadclick()
    {
        SceneManager.LoadScene("firstlevel");
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
