using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && ProgressionManager.isProgressing == false)
        {
			if(nav.enabled == false)
			{
				nav.enabled = true;
			}
            nav.SetDestination (player.position);
        }
		else
        {
            nav.enabled = false;
        }
    }
}
