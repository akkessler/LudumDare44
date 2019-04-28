using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour {

    public static List<CurrencyPickup> activeCurrency;

    public Transform coinPrefab;
    public Transform billPrefab;
    public Currency[] currencyList;

    public float spawnRate = 1f;
    private float spawnTimer = 0f;

    private float width;
    private float height;

    private float halfWidth;
    private float halfHeight;

    float planeScalar = 10f; // Unity default plane is 10 units

    // Use this for initialization
    void Start () {
        activeCurrency = new List<CurrencyPickup>();
        spawnTimer = 0f;
        width = transform.localScale.x * planeScalar;
        height = transform.localScale.z * planeScalar;
        halfWidth = width / 2;
        halfHeight = height / 2;
	}

	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnRate)
        {
            SpawnCurrency();
            spawnTimer = 0;
        }
	}

    public void SpawnCurrency() {
        float padding = planeScalar; // prevents currency from spawning inside of walls
        float randomX = Random.Range(padding - halfWidth, halfWidth - padding);
        float randomZ = Random.Range(padding - halfHeight, halfHeight - padding);
        int randomIndex = Random.Range(0, currencyList.Length);
        Currency currency = currencyList[randomIndex];
        Transform currencyPrefab = currency.value < 1f ? coinPrefab : billPrefab;
        Transform spawn = Instantiate(currencyPrefab, new Vector3(randomX, currencyPrefab.transform.position.y, randomZ), Quaternion.identity);
        CurrencyPickup pickup = spawn.GetComponent<CurrencyPickup>();
        pickup.currency = currency;
        activeCurrency.Add(pickup);
    }

    public static void Release(CurrencyPickup forsaken)
    {
        activeCurrency.Remove(forsaken);
        Destroy(forsaken.gameObject);
        // TODO Object pooling
    }
}
