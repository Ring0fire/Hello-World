using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

public GameObject DestructionPoint;

	// Use this for initialization
	void Start () {
		DestructionPoint = GameObject.Find ("destructionPoint");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < DestructionPoint.transform.position.x)
		{
			gameObject.SetActive(false);
		}
	}
}
