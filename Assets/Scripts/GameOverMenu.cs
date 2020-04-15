using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame()
	{
		FindObjectOfType<GameManager>().Reset();
	}
	public void QuitToMain()
	{
		Application.LoadLevel (mainMenuLevel);
	}
}
