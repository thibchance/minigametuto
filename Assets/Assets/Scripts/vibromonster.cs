using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibromonster : MonoBehaviour {

    [SerializeField]
    AnimationCurve vibro;

    private Vector3 positionInitial;
    [SerializeField]
    [Range(0.5f,5f)]
    private float timemax = 4;
    private float vibrateAmplificateur = 2;
	// Use this for initialization
	void Start ()
    {
        positionInitial = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float currentTime = Time.timeSinceLevelLoad % timemax;
        currentTime /= timemax - 1;
        float positionY = vibro.Evaluate(currentTime);
        positionY *= vibrateAmplificateur;
        Vector3 newposition = new Vector3(positionInitial.x, positionY + positionInitial.y, positionInitial.z);
        transform.position = newposition;
	}
}
