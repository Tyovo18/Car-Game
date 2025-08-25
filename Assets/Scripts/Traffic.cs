using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private Transform[] tabSpawn;
    private int nbCars = 0;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            int nb = Random.Range(0, cars.Length);
            int valSpawn = Random.Range(0, tabSpawn.Length);

            Instantiate(cars[nb], tabSpawn[valSpawn].position, transform.rotation);
            nbCars++;

            if (nbCars % 5 == 0)
            {
                spawnRate = Mathf.Max(0.3f, spawnRate - 0.1f);
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void IncreaseCarCount()
    {
        nbCars++;
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public void StopOppositeCars()
    {
        GameObject[] oppositeCars = GameObject.FindGameObjectsWithTag("OppositeCar");
        foreach (GameObject car in oppositeCars)
        {
            MoveOCar moveOCar = car.GetComponent<MoveOCar>();
            if (moveOCar != null)
            {
                moveOCar.enabled = false;
            }
        }
    }
}
