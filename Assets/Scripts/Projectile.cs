using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x > 16)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -16)
        {
            Destroy(gameObject);
        }
    }
}
