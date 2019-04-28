﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour {

    public Currency currency;

    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = currency.material;
        transform.localScale *= currency.scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        PiggyBank pig = other.GetComponent<PiggyBank>();
        if (pig != null && pig.tag == "Player")
        {
            pig.AddCurrency(currency);
            Destroy(gameObject); // TODO Use object pool
        }
    }

    
}