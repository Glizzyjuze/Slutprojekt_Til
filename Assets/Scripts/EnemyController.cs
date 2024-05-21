using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject laserPrefab;

    [SerializeField] float moveSpeed = 1;
    [SerializeField] float laserSpeed;
    [SerializeField] float hp;
    [SerializeField] public float fireRate;
    public float maxFireRate;

    Vector2 movement = new Vector2(-1, 0);
    Vector2 firePoint;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        maxFireRate = fireRate;

        float y = Random.Range(-8.5f, 8.5f);
        
        float x = 18f;

        transform.position = new(x, y);
        transform.rotation = new(0, 0, 180, 0);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        fireRate -= 1;

        if (fireRate < 0)
        {
            Shoot();
            fireRate = maxFireRate;
        }

        firePoint.x = gameObject.transform.position.x - 2;
        firePoint.y = gameObject.transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            hp -= 1;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint, gameObject.transform.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(gameObject.transform.right * laserSpeed, ForceMode2D.Impulse);  
    }
}
