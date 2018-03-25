using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lat : MonoBehaviour {
    public Transform target;
    public float maxSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + getSteering()._velocity * Time.deltaTime;
    }
    KinematicData getSteering()
    {
        KinematicData steering = new KinematicData();
        steering._velocity = target.position - transform.position;
        steering._velocity.Normalize();
        steering._velocity *= maxSpeed;
        transform.eulerAngles = getOrientation(transform.eulerAngles, steering._velocity);
        steering._rotation = Vector3.zero;
        return steering;
    }
    Vector3 getOrientation(Vector3 charRotation, Vector3 velocity)
    {
        if(velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(velocity.x, velocity.z);
            return new Vector3(0, angle, 0);
        }
        else
        {
            return charRotation;
        }
    }
}
