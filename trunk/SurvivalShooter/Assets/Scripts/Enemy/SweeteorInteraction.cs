using UnityEngine;
using System.Collections;

public class SweeteorInteraction : MonoBehaviour {


	public int rotateX = 15;
	public int rotateY = 30;
	public int rotateZ = 35;
	public int startHeight = 20;
	public float drag = 0.05f;
	public float force = 5f;
	public int attackDamage = 100;
	public float sinkSpeed = 1f;

	private Rigidbody rigidbodySweeteor;
	private GameObject player;
	private Vector3 currentPosition;
	private Vector3 forceVector;
	private bool firstUpdate;
//	private Collider mesh;
	private bool hasImpacted = false;
	private PlayerHealth playerHealth;
	private bool playerHit = false;
	private bool isSinking = false;


	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidbodySweeteor = GetComponent<Rigidbody>();
//		mesh = GetComponent<Collider> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Start (){

		rigidbodySweeteor.useGravity = false;
		rigidbodySweeteor.drag = drag;
		firstUpdate = true;
	}

	void FixedUpdate () {

		if (hasImpacted == false) {
			transform.Rotate (new Vector3 (15, 30, 35) * Time.deltaTime);
			if (firstUpdate) {
				CalculateForce ();
				firstUpdate = false;
			}
			rigidbodySweeteor.AddForce (forceVector);
		} else if (hasImpacted == true && rigidbodySweeteor.velocity.magnitude < 0.01 && isSinking == false){
			StartSinking();
		}
	}
	void Update(){
		if (playerHit == true && ProgressionManager.isProgressing == false) {
			//Debug.Log("Player got Hit");
			if(playerHealth.currentHealth > 0)
			{
				//Debug.Log("Player got Hit");
				playerHealth.TakeDamage (attackDamage);
			}
		}
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime,Space.World);
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (hasImpacted == false) {
			hasImpacted = true;
			//Debug.Log ("There has been a collision");
			rigidbodySweeteor.useGravity = true;
			if (other.gameObject == player) {
				//Debug.Log("Player Collision");
				playerHit = true;
			}
		}
	}
	
	void CalculateForce (){
		currentPosition = transform.position;
		forceVector = player.transform.position - currentPosition;
		forceVector.Normalize ();
		forceVector = forceVector * force; 
	}

	void StartSinking (){
		isSinking = true;
		rigidbodySweeteor.isKinematic = true;
		Destroy (gameObject, 5f);
	}
}
