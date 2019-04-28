using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour {

    public static List<PiggyBank> activePigs;

    public Transform pigPrefab;

    public int maxPigs = 20;
    public float spawnRate = 5f;
    private float spawnTimer = 0f;

    private float width;
    private float height;

    private float halfWidth;
    private float halfHeight;

    float planeScalar = 10f; // Unity default plane is 10 units

    void Start()
    {
        activePigs = new List<PiggyBank>();
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
            if (activePigs.Count < maxPigs)
            {
                SpawnPig();
            }
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
        pig.value = Random.Range(0f, PlayerController.pig.value * 1.25f);
        activePigs.Add(pig);
    }

    public static void Release(PiggyBank forsaken)
    {
        activePigs.Remove(forsaken);
        Destroy(forsaken.gameObject);
    }
}
