using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	public PlayerController myPlayer;
	
	private Renderer myRenderer;
	
	
    // Start is called before the first frame update
    void Start()
    {
		myPlayer = FindObjectOfType<PlayerController>();
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 offset = new Vector2(Time.time * (1/myPlayer.moveSpeed), 0);
		myRenderer.material.mainTextureOffset = offset;
        
    }
}
