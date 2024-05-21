using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    [SerializeField] public float speed;
    [SerializeField] public float fireRate;
    private float maxFireRate;

    void Start()
    {
        maxFireRate = fireRate;
    }

    void Update()
    {
        fireRate -= 1;

        if (Input.GetButtonDown("Jump") && fireRate <= 0)
        {
            Shoot();
            fireRate = maxFireRate;
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
    }
}
