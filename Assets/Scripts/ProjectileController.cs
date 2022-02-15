using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private OnClickShoot onClickShoot; // Calling Shoot Script
    private GameManager gameManager; // Calling Game Manager Script

    private GameObject target;
    private Rigidbody targetRb;


    void Start()
    {
        // Initializing scripts & Game Object
        onClickShoot = GameObject.Find("Background").GetComponent<OnClickShoot>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        target = GameObject.Find("Target");

        targetRb = target.GetComponent<Rigidbody>(); // Getting Rigidbody of Target Game object
    }

    void OnCollisionEnter(Collision collision) // Checking Collision of Projectile with other Game Objects
    {
        onClickShoot.speed = 0;
        gameManager.isCollision = true;
        if (collision.gameObject.CompareTag("Target")) // Checking Collision with Target
        {
            gameObject.tag = "Player";
            transform.parent = target.transform;
            Destroy(this);
        }
        else if (collision.gameObject.CompareTag("Player")) // Checking Collision with other projectiles
        {
            gameManager.isGameover = true;
            targetRb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnMouseDown()
    {
        // Setting speed if projectile is clicked
        onClickShoot.speed = 50;
    }
}
