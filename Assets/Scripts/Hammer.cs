using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    public Vector3 direction;
    public float speed = 1f;
    public float degreesPerSecond = 360f;

    public float minDamage = 1f;
    public float damagePercent = 0.10f;

    public AudioClip audioClip;

    void Update () {
        transform.position += speed * direction * Time.deltaTime;
        transform.Rotate(Vector3.up, degreesPerSecond * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PiggyBank pig = other.GetComponent<PiggyBank>();
        if (pig != null)
        {
            if (pig.tag == "Player")
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip);
            }
            pig.RemoveValue(Mathf.Max(pig.value * damagePercent, minDamage));
            // TODO Add coin spray effect
            if (pig.value < 0)
            {
                PigSpawner.Release(pig);
                // TODO Shatter effect
            }
            HammerSpawner.Release(this);
        }
    }

}
