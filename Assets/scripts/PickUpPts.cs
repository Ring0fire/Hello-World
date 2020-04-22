using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPts : MonoBehaviour{
	
	public int scoreToGive;
	
	private ScoreManager theScoreManager;
	
	//private AudioSource audio ;
	
    // Start is called before the first frame update
    void Start(){
        theScoreManager = FindObjectOfType<ScoreManager>();
		
	// audio = GameObject.Find("selected audio clip").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Player")
		{
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive(false);
			
/*		when audio is added, replace 'audio' with sound clip of getting a truffle	
			if(audio.isPlaying)
			{
				audio.Stop();
				audio.Play();
			}
			else{
			audio.Play();	
			}*/
		}
	
	}
}
