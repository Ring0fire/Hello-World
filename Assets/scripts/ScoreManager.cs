using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	public Text distanceText;
	public Text hiScoreText;
	
	public float scoreCount;
	public float distanceCount;
	public float hiScoreCount;
	
	public float distPerSecond;
	
	public bool distIncreasing;
	
	public bool doublePoints;
	
    // Start is called before the first frame update
    void Start(){
        if(PlayerPrefs.HasKey("HighScore"))
		{
			hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		}	
    }

    // Update is called once per frame
    void Update(){
		
		if(distIncreasing)
		{
			distanceCount += distPerSecond * Time.deltaTime;
			scoreCount += distPerSecond * Time.deltaTime;
		}	

		if(scoreCount> hiScoreCount)
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore", hiScoreCount);
		}	
		
		distanceText.text = "Distance:" + Mathf.Round(distanceCount) + "M";	
		scoreText.text = "Score:" + Mathf.Round(scoreCount) + "pts";
		hiScoreText.text = "Hi Score:" + Mathf.Round(hiScoreCount) + "pts";
	}
	
	public void AddScore(int pointsToAdd){
		if(doublePoints)
		{
			pointsToAdd = pointsToAdd * 2;
		}
	scoreCount += pointsToAdd;
	}
}
