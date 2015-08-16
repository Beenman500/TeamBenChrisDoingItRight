using UnityEngine;
using System.Collections;

public class SweeteorManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 5f;
	public float startHeight = 30f;
	public static int initialSweeteorLevel = 5;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0f || ProgressionManager.isProgressing || ProgressionManager.currentLevel < initialSweeteorLevel)
		{
			return;
		}

		float spawnPointX = Random.Range (-20, 20);
		float spawnPointZ = Random.Range (-20, 20);
		
		Instantiate (enemy, new Vector3 (spawnPointX, startHeight, spawnPointZ), enemy.transform.rotation);
	}
}
