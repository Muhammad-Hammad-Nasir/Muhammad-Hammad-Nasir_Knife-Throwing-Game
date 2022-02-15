using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private ProjectileController projectileController;  // Calling projectile Script
    private Vector3 projectilePos;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI daggers;

    public GameObject gameover;
    public GameObject projectilePrefab;
    public bool isGameover;
    public bool isCollision;
    public int health;
    public int score;

    void Start()
    {
        health = 7;  // Initializing Health
        score = 0;  // Initializing Score
        projectilePos = new Vector3(0, -5, 0);  // Setting prefab spawn position

        projectileController = GameObject.Find("Projectile").GetComponent<ProjectileController>();  // Initializing Scripts
    }

    void Update()
    {
        CheckCollision();
        DisplayScreen();
    }

    void CheckCollision()  // Checking Collision of projectile with Game Objects
    {
        if (isCollision == true && isGameover == false)
        {
            health--;  // Reducing Number of Projectiles
            score += 5;  // Adding Score
            Instantiate(projectilePrefab, projectilePos, projectilePrefab.transform.rotation);  // Creating new Projectiles
            isCollision = false;
        }
    }

    void DisplayScreen()
    {
        scoreText.text = "Score: " + score;  // Score Display
        daggers.text = "Daggers: " + health;  // Projectiles Display
        if (isGameover && health > 0) // If GameOver due to loss
        {
            gameover.SetActive(true);
        }
    }
}
