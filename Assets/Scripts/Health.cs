using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private GameObject enemyPrefab;

    public float hp;
    [SerializeField] float maxHp;

    void Start()
    {
        hp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Damage();
        }

        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            Damage();
        }
    }

    void Update()
    {
        enemyPrefab = GameObject.FindGameObjectWithTag("Enemy");

        if (hp > maxHp)
        {
            hp = maxHp;
        } else if (hp <= 0f)
        {
            hp = 0f;    
        }

        if (hp == 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (enemyPrefab != null && enemyPrefab.transform.position.x <= -16)
        {
            Damage();
            Destroy(enemyPrefab);
        }
    }

    void Damage()
    {
        hp -= 1;
    }
}
