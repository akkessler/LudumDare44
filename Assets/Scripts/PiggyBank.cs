using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PiggyBank : MonoBehaviour {

    public float value;
    public float scale;

    private Vector3 defaultLocalScale;
    private const float scaleToValueRatio = 3f / 100f;

    public AudioClip audioClipGrow;
    public AudioClip audioClipShrink; // TODO Use this for gameover sound?

    void Start() {
        //value = 0f;
        defaultLocalScale = transform.localScale;
        UpdatePositionAndScale();
    }
    void UpdatePositionAndScale()
    {
        transform.localScale = defaultLocalScale + (Vector3.one * scale);
        transform.position = new Vector3(transform.position.x, 4 * transform.localScale.y, transform.position.z);
    }

    public void AddCurrency(Currency currency)
    {
        AddValue(currency.value);
    }

    public void RemoveValue(float v)
    {
        AddValue(-v);
    }

    // Check that it is positive?
    public void AddValue(float v)
    {
        value = (float) Math.Round(value + v, 2);
        scale = (float) Math.Round(value * scaleToValueRatio, 2);
        UpdatePositionAndScale();
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        PiggyBank other = collision.collider.GetComponent<PiggyBank>();
        if(other != null && other.value < value)
        {
            if(other.value < value)
            {
                if (tag == "Player") Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClipGrow);
                AddValue(other.value * 0.5f);
                PigSpawner.Release(other);
            }
        }
    }

}
