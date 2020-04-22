using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruffleGenerator : MonoBehaviour
{
	public ObjectPooler trufflePool;
	
	private float truffPlacement;

	public void SpawnTruffles (Vector3 startPosition)
	{
		truffPlacement = Random.Range(0f, 3f);
		GameObject truffle1 = trufflePool.GetPooledObject();
		truffle1.transform.position = new Vector3 (startPosition.x + truffPlacement, startPosition.y + (truffPlacement/2), startPosition.z);
		truffle1.SetActive (true);
		/*
		
		platformSelector = Random.Range(0, theObjectPools.Length);
			
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])*2, transform.position.y, transform.position.z);
			
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
		GameObject truffle2 = trufflePool.GetPooledObject();
		truffle2.transform.position = new Vector3(startPosition.x - distanceBetweenTruffles, startPosition.y, startPosition.z);
		truffle2.SetActive (true);
		
		GameObject truffle3 = trufflePool.GetPooledObject();
		truffle3.transform.position = new Vector3(startPosition.x + distanceBetweenTruffles, startPosition.y, startPosition.z);
		truffle3.SetActive (true);
		*/
	}
}
