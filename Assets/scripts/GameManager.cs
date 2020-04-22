using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform objectGenerator;
	private Vector3 platformStartPoint;
	
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;
	
	private ObjectDestroyer[] objectList;
    
	private ScoreManager theScoreManager;
	
	public GameOverMenu theGameOverScreen;
	public bool powerupReset;
	
	// Start is called before the first frame update
    void Start()
    {
        platformStartPoint = objectGenerator.position;
		playerStartPoint = thePlayer.transform.position;
    
		theScoreManager = FindObjectOfType<ScoreManager>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void RestartGame()
	{
		theScoreManager.distIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		theGameOverScreen.gameObject.SetActive(true);
	}
	
	public void Reset()
	{
		theGameOverScreen.gameObject.SetActive(false);		
		objectList = FindObjectsOfType<ObjectDestroyer>();
		for(int i =0; i < objectList.Length; i++)
		{
			objectList[i].gameObject.SetActive(false);
		}
		thePlayer.transform.position = playerStartPoint;
		objectGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.distanceCount = 0;
		theScoreManager.distIncreasing = true;
		
		powerupReset = true;
	}
	
}
