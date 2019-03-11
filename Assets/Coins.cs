using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
	public List<GameObject> myObjectPool;
	public GameObject coinPrefab;
	private int pooledIndex = 0;

	void ObjectPoolSetup() {
	// Instantiate the empty list. 
		myObjectPool = new List<GameObject>(); 
		for(var i = 0; i < 10; i++) { 
			GameObject coin = Instantiate(coinPrefab);
			myObjectPool.Add(coin);	
			coin.SetActive(false);
		}
	}

	public GameObject GetPooledObject() {
		pooledIndex++; 
		if(pooledIndex >= myObjectPool.Count) {
			// Reset it to 0 if the number is larger than the number of objects we have in the pool.
			pooledIndex = 0; 
		} 

		if (myObjectPool[pooledIndex].activeSelf) {
			foreach(GameObject pooledObject in myObjectPool) {
				// If the object is not active... 
				if(!pooledObject.activeSelf) {
					// return that one. 
					return pooledObject;
				}
			}
			// If it gets down here, we have no available objects in the pool.
			GameObject coin = Instantiate(coinPrefab);
			myObjectPool.Add(coin);
			coin.SetActive(false);
			return coin;
		} else {
			return myObjectPool[pooledIndex];
		}
	}
}
