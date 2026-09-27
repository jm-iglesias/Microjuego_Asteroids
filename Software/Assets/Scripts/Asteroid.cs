using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float maxTimeLife = 8f;
    public float xlimit, ylimit;
    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
       if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            SpawnAsteroid();
        } 
    }

    private void SpawnAsteroid()
    {
        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        float margin = 1.5f;
        Vector3 spawnPos = Vector3.zero;
        Vector3 trajectory = Vector3.zero;
        int edge = Random.Range(0, 4);
        switch (edge)
        {
            case 0:
                spawnPos = new Vector3(Random.Range(-width, width), height + margin, -1f);
                break;
            case 1:
                spawnPos = new Vector3(Random.Range(-width, width), -height - margin, -1f);
                break;
            case 2:
                spawnPos = new Vector3(-width - margin, Random.Range(-height, height), -1f);
                break;
            case 3:
                spawnPos = new Vector3(width + margin, Random.Range(-height, height), -1f);
                break;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            trajectory = (player.transform.position - spawnPos).normalized;
        }
        else
        {
            trajectory = (Vector3.zero - spawnPos).normalized;
        }
        GameObject meteor = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        Destroy(meteor, maxTimeLife);
        AsteroidFragmentation movement = meteor.GetComponent<AsteroidFragmentation>();
        if (movement != null)
        {
            movement.SetDirection(trajectory);
        }
    }
}
