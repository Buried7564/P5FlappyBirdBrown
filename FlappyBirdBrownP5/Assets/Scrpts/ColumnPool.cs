using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float SpawnRate = 4f;
    public float cloumnmin = -1f;
    public float cloumnmax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private int currentColumn = 0;
    private float spawnXPosition = 6f;
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns [i] = GameObject.Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameover == false && timeSinceLastSpawned >= SpawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(cloumnmin, cloumnmax);
            columns[currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
