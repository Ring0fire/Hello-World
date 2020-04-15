using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {
	
	public int scoreToGive;
	
	private ScoreManager theScoreManager;

	private AudioSource truffGet;
	//audio lines truffGet (truffle collection SFX)-18,33
	//truffGet multiple Get resolution 33-37
	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();
	
		truffGet = GameObject.Find("TruffleCollect").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive(false);
			
			if(truffGet.isPlaying)
			{
				truffGet.Stop();
				truffGet.Play();
			}
			else{
			truffGet.Play();
			}
		}
	}
	
}
