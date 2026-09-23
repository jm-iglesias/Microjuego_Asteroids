using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float maxTimeLife = 2f;
    public float xlimit;
    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
       if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            float rand = Random.Range(-xlimit, xlimit);
            Vector3 spawnPosition  = new Vector3(rand, 8f, -1f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteor, maxTimeLife);
        } 
    }
}
