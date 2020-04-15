using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruffleGenerator : MonoBehaviour {

	public ObjectPooler trufflePool;
	
	public float distanceBetweenTruffles;

	public void SpawnTruffles (Vector3 startPosition)
	{
		GameObject truffle1 = trufflePool.GetPooledObject();
		truffle1.transform.position = startPosition;
		truffle1.SetActive (true);
		
		GameObject truffle2 = trufflePool.GetPooledObject();
		truffle2.transform.position = new Vector3(startPosition.x - distanceBetweenTruffles, startPosition.y, startPosition.z);
		truffle2.SetActive (true);
		
		GameObject truffle3 = trufflePool.GetPooledObject();
		truffle3.transform.position = new Vector3(startPosition.x + distanceBetweenTruffles, startPosition.y, startPosition.z);
		truffle3.SetActive (true);
		
	}
	
}
