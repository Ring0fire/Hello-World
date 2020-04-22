using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
	private bool doublePts;

	private bool powerupActive;
	
	private float powerupLengthCounter;
	
	private ScoreManager theScoreManager;
	private ObjectGenerator theObjectGenerator;
	private GameManager theGameManager;
	
	private float normalPtsPerSecond;
	private float pithzdRate;
	
	private ObjectDestroyer [] pithzdList;
	
	
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
		theObjectGenerator = FindObjectOfType<ObjectGenerator>();
		theGameManager = FindObjectOfType <GameManager>();
    }

    // Update is called once per frame
    void Update(){
		if(powerupActive)
		{
			powerupLengthCounter -= Time.deltaTime;
			
			if(theGameManager.powerupReset)
			{
				powerupLengthCounter = 0;
				theGameManager.powerupReset = false;
			}
			
			if(doublePts)
			{
				theScoreManager.distPerSecond = normalPtsPerSecond * 1f;
				theScoreManager.doublePoints = true;
			}
			
			if(powerupLengthCounter <= 0)
			{
			theScoreManager.distPerSecond = normalPtsPerSecond;
			theScoreManager.doublePoints = false;
			
			theObjectGenerator.rndPitHzdThreshold = pithzdRate;
		
			powerupActive = false;
			}
		}     
    }
	public void ActivatePowerup(bool points, float time){
		doublePts = points;
		powerupLengthCounter = time;
		
		normalPtsPerSecond = theScoreManager.distPerSecond;
		pithzdRate = theObjectGenerator.rndPitHzdThreshold;
		
		powerupActive = true;
	}	
}
