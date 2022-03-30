using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Mirror;
public class EnemyController : NetworkBehaviour
{
    //[SerializeField] GameObject getHit; //for particle system hit effect
    //[SerializeField] GameObject getDeath; // //for particle system Death effect
    [SerializeField] int health = 10;
    [SerializeField] int pointValue = 100;

    AudioSource audioSource;
    int current_Health;

    void OnEnable()
    {
        current_Health = health;
    }
    void Update()
    {
        if (isServer == false)
            return;
        var player = FindObjectOfType<PlayerController>();
        //GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
    public void TakeDamage(/*Vector3 impactPoint ,*/ int amount)
    {
        current_Health -= amount;
       // Instantiate(getHit, impactPoint, transform.rotation);

        /*if(audioSource != null)
            audioSource.Play();*/
        if(current_Health <= 0)
        {
            // Instantiate(getDeath, impactPoint, transform.rotation);
            //gameObject.SetActive(false);
            Destroy(gameObject);

            ScoreContoller.Add(pointValue);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if (collision.tag == "Player")
        {
            Debug.Log("Player Get Hit");
        }
    }
}
