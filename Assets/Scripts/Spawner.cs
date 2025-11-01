using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cars;
    readonly float spawnPosX = 1.2f;

    void Start()
    {
        SpawnCar();
    }

    // Spawn a new car
    public void SpawnCar()
    {
        float randomX = (Random.value < 0.5f) ? -spawnPosX : spawnPosX;
        Vector3 spawnPos = new(randomX, 9, 0f);

        GameObject selectedCar = cars[Random.Range(0, cars.Length)];
        Instantiate(selectedCar, spawnPos, selectedCar.transform.rotation);

    }
}
