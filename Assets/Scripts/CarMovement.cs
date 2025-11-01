using UnityEngine;

public class CarMovement : MonoBehaviour
{
    float baseSpeed = 4f;
    float acceleration = 0.3f;
    public float speed;
    private Spawner spawner;
    bool canSpawn = true;

    void Start()
    {
        spawner = FindFirstObjectByType<Spawner>();
    }


    void Update()
    {
        speed = baseSpeed + acceleration * Time.time;
        speed = Mathf.Min(speed, 20f);

        transform.Translate(speed * Time.deltaTime * Vector3.down);

        if (transform.position.y <= 2 && canSpawn)
        {
            spawner.SpawnCar();
            canSpawn = false;
        }

        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }
}
