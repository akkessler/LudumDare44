using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1f;
    public float arriveDistance = 0.25f;

    private bool isMoving;
    private Vector3 targetPosition;

    private bool isRotating;
    private Quaternion targetRotation;
    
	void Update () {
        MoveUsingMousePosition();
        FollowPlayerWithMainCamera();
    }

    void FollowPlayerWithMainCamera()
    {
        // Consider smoothing with lerp or something.
        Camera.main.transform.position = new Vector3(
            transform.position.x,
            Camera.main.transform.position.y,
            transform.position.z
        );
    }

    void MoveUsingMousePosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist = 0f;
        if (plane.Raycast(ray, out dist))
        {
            targetPosition = ray.GetPoint(dist);
            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

        }

        // null checks?
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
}
