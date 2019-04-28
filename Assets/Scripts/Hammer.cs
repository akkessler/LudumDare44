using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    public float speed;
    public Vector3 dir;

	void Start () {
		
	}
	
	void Update () {
        transform.position += speed * dir * Time.deltaTime;
	}
}
