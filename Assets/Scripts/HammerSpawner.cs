using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSpawner : MonoBehaviour {

    public Transform hammerPrefab;

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
            SpawnHammer();
            spawnTimer = 0;
        }
    }

    enum Wall { North, East, South, West };
    public void SpawnHammer()
    {
        float spawnX = 0f;
        float spawnZ = 0f;
        Vector3 dir = Vector3.zero;
        switch ((Wall) Random.Range(0, 4))
        {
            case Wall.North:
                spawnX = Random.Range(-halfWidth, halfWidth);
                spawnZ = halfHeight;
                dir = Vector3.back;
                break;
            case Wall.South:
                spawnX = Random.Range(-halfWidth, halfWidth);
                spawnZ = -halfHeight;
                dir = Vector3.forward;
                break;
            case Wall.East:
                spawnX = halfWidth;
                spawnZ = Random.Range(-halfHeight, halfHeight);
                dir = Vector3.left;
                break;
            case Wall.West:
                spawnX = -halfWidth;
                spawnZ = Random.Range(-halfHeight, halfHeight);
                dir = Vector3.right;
                break;
        }
        Vector3 spawnPosition = new Vector3(spawnX, hammerPrefab.transform.position.y, spawnZ);
        Transform spawn = Instantiate(hammerPrefab, spawnPosition, Quaternion.identity);
        Hammer hammer = spawn.GetComponent<Hammer>();
        hammer.dir = dir;
        hammer.speed = 5f;
        Debug.Log(hammer.name);
    }
}
