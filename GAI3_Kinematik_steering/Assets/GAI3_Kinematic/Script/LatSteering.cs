using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatSteering : MonoBehaviour {
    public Transform target;
    public float maxSpeed;
    public float maxAcc;
    private Vector3 velocity;
	void Update () {
        transform.position += velocity * Time.deltaTime;
        velocity += getSteering()._linear * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
	}
    SteeringData getSteering()
    {
        SteeringData steering = new SteeringData();
        steering._linear = target.position - transform.position;
        steering._linear.Normalize();
        steering._linear *= maxAcc;
        steering._angular = Vector3.zero;
        return steering;
    }
}
