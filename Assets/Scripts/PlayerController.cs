using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PiggyBank pig; // access this in a better way?
    private float pigDefaultSpeed;

    private bool isMoving;
    private Vector3 targetPosition;

    private bool isRotating;
    private Quaternion targetRotation;

    private bool isBoosting;
    public float speedBoostMagnitude;
    public float speedBoostCooldown;
    public float speedBoostDuration;
    private float speedBoostCooldownTimer;
    private float speedBoostDurationTimer;


    void HandleSpeedBoost()
    {
        if (isBoosting)
        {
            speedBoostDurationTimer -= Time.deltaTime;
            if (speedBoostDurationTimer <= 0)
            {
                isBoosting = false;
                pig.speed = pigDefaultSpeed;
            }
        }

        speedBoostCooldownTimer -= Time.deltaTime;
        if (speedBoostCooldownTimer <= 0)
        {
            speedBoostCooldownTimer = 0;
            if(Input.GetKeyUp(KeyCode.Space))
            {
                isBoosting = true;
                speedBoostCooldownTimer = speedBoostCooldown;
                speedBoostDurationTimer = speedBoostDuration;
                pig.speed = pigDefaultSpeed * speedBoostMagnitude;
            }
        }
    }

    private void Start()
    {
        pig = GetComponent<PiggyBank>();
        pigDefaultSpeed = pig.speed;
        speedBoostCooldownTimer = 0;
        speedBoostDurationTimer = 0;
    }

    void Update () {
        MoveUsingMousePosition();
        FollowPlayerWithMainCamera();
        HandleSpeedBoost();
    }

    void FollowPlayerWithMainCamera()
    {
        // Consider smoothing with lerp or something.
        Camera.main.transform.position = new Vector3(
            transform.position.x,
            50f + ((transform.localScale.y - 0.5f) * (50f / 3f)), //Camera.main.transform.position.y,
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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, pig.speed * Time.deltaTime);
        transform.rotation = targetRotation;
    }

}
