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


        // THIS IS FOR THE MAIN MENU (SHOULD REALLY GO SOMEWHERE ELSE)
        SpawnPig(); SpawnPig(); SpawnPig();
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
        // FIXME could make this simpler by moving plane to be in +xz quadrant.
        float randomX = Random.Range(padding - halfWidth, halfWidth - padding);
        float randomZ = Random.Range(padding - halfHeight, halfHeight - padding);
        Transform spawn = Instantiate(pigPrefab, new Vector3(randomX, pigPrefab.transform.position.y, randomZ), Quaternion.identity);
        PiggyBank pig = spawn.GetComponent<PiggyBank>();
        // 0.8f since don't want to spawn pigs that can auto kill player (need check to prevent spawning on top of player)
        float maxValue = PlayerController.pig != null ? PlayerController.pig.value * .8f : 10f;
        pig.value = Random.Range(0f, maxValue); 
        activePigs.Add(pig);
    }

    public static void Release(PiggyBank forsaken)
    {
        if (forsaken.tag == "Player")
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(forsaken.audioClipShrink);
            GameManager.Instance.LoseGame(forsaken.value);
        }
        else
        {
            activePigs.Remove(forsaken);
        }
        Destroy(forsaken.gameObject);
    }
}
