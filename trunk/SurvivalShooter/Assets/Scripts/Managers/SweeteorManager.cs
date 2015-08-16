using UnityEngine;
using System.Collections;

public class SweeteorManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 5f;
	public float startHeight = 30f;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0f || ProgressionManager.isProgressing)
		{
			return;
		}

		float spawnPointX = Random.Range (-20, 20);
		float spawnPointZ = Random.Range (-20, 20);
		
		Instantiate (enemy, new Vector3 (spawnPointX, startHeight, spawnPointZ), enemy.transform.rotation);
	}
}
