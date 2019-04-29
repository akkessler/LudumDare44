using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyPickup : MonoBehaviour {

    public Currency currency;

    private MeshRenderer meshRenderer;

    private TextMeshPro tmp;

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = currency.material;
        transform.localScale *= currency.scale;

        tmp = transform.GetComponentInChildren<TextMeshPro>();
        if(currency.value < 1)
        {
            int cents = (int) (currency.value * 100);
            tmp.SetText(cents.ToString());
        }
        else
        {
            int dollars = (int) currency.value;
            tmp.SetText(dollars.ToString());
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        PiggyBank pig = other.GetComponent<PiggyBank>();
        if (pig != null)
        {
            if (pig.tag == "Player")
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(currency.pickupSound);
            }
            pig.AddCurrency(currency);
            CurrencySpawner.Release(this);
        }
    }

    
}
