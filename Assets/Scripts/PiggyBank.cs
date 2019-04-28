using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBank : MonoBehaviour {

    public float value;

    private Vector3 defaultLocalScale;

    void Start() {
        value = 0f;
        defaultLocalScale = transform.localScale;
    }

    // Check that it is positive?
    public void AddCurrency(Currency currency)
    {
        Debug.Log("Adding currency: " + currency.value);
        value += currency.value;
        transform.localScale = defaultLocalScale * LookupScaleBasedOnValue();
    }

    public float LookupScaleBasedOnValue()
    {
        if (value < 1f) return 1f;
        if (value < 5f) return 2f;
        if (value < 10f) return 3f;
        if (value < 20f) return 4f;
        if (value < 50f) return 5f;
        if (value < 100f) return 6f;
        return 7f;
    }

}
