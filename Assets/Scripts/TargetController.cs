using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour
{
    private float rotateSpeed;
    public GameManager gameManager;
    public GameObject winText;

    void Start()
    {
        rotateSpeed = Random.Range(100f, 150f);  // Set speed of rotation
    }

    void Update()
    {
        if (gameManager.isGameover == false)  // Check if game is not over
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);  // Rotating Target Game Object at start of game
            if (gameManager.health <= 0 && gameManager.isGameover == false)  // Checking Win Condition
            {
                Destroy(gameObject);  // Target is destroyed
                gameManager.isGameover = true;
                winText.SetActive(true);  // Win text set to true
            }
        }
    }
}
