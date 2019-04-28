using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour {

    public Transform pigPrefab;

    public float spawnRate = 5f;
    private float spawnTimer = 0f;

    private float width;
    private float height;

    private float halfWidth;
    private float halfHeight;

    float planeScalar = 10f; // Unity default plane is 10 units

    // Use this for initialization
    void Start()
    {
        spawnTimer = 0f;
        width = transform.localScale.x * planeScalar;
        height = transform.localScale.z * planeScalar;
        halfWidth = width / 2;
        halfHeight = height / 2;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            SpawnPig();
            spawnTimer = 0;
        }
    }

    public void SpawnPig()
    {
        float padding = planeScalar; // prevents currency from spawning inside of walls
        float randomX = Random.Range(padding - halfWidth, halfWidth - padding);
        float randomZ = Random.Range(padding - halfHeight, halfHeight - padding);
        Transform spawn = Instantiate(pigPrefab, new Vector3(randomX, pigPrefab.transform.position.y, randomZ), Quaternion.identity);
        PiggyBank pig = spawn.GetComponent<PiggyBank>();
        Debug.Log(pig.name);
    }
}
