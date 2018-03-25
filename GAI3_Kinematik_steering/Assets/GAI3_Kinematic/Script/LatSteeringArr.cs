using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatSteeringArr : MonoBehaviour {
    public Transform target;
    public float maxSpeed;
    public float maxAcc;
    public float targetRadius;
    public float slowRadius;
    private Vector3 velocity;
	// Update is called once per frame
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
        float targetSpeed;
        Vector3 targetVelocity;
        SteeringData steering = new SteeringData();
        steering._linear = target.position - transform.position;
        float distance = steering._linear.magnitude;
        if (distance > slowRadius)
        {
            targetSpeed = maxAcc;
        }
        else if(distance<=targetRadius)
        {
            targetSpeed = 0;
        }
        else
        {
            targetSpeed = maxSpeed * distance / slowRadius;
        }
        targetVelocity = steering._linear.normalized * targetSpeed;
        steering._linear = targetVelocity - velocity;
        if (steering._linear.magnitude > maxAcc)
        {
            steering._linear.Normalize();
            steering._linear *= maxAcc;
        }
        return steering;
    }
}
