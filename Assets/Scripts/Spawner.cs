using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyShipPrefab;

    [SerializeField] private float spawnRate;
    float spawnRateAcceleration;

    [SerializeField] bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn == true)
        {
            yield return wait;

            Instantiate(enemyShipPrefab, transform.position, Quaternion.identity);
        }
    }
}
