using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickShoot : MonoBehaviour
{
    private GameObject projectilePrefab;
    public float speed;

    void Start()
    {
        speed = 0; // Initializing Speed
    }

    void Update()
    {
        projectilePrefab = GameObject.FindGameObjectWithTag("Projectile"); // Initializing projectile prefab
        if (projectilePrefab)
        {
            projectilePrefab.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    void OnMouseDown()
    {
        // Setting spped if background is clicked
        speed = 50;
    }
}
