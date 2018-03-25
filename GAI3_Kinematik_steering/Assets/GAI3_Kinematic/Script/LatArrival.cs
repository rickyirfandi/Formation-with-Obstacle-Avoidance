using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatArrival : MonoBehaviour {
    public Transform target;
    public float maxspeed;
    public float radius;
    public float timetoTarget;
	// Update is called once per frame
	void Update () {
        transform.position += getSteering()._velocity * Time.deltaTime;
	}
    KinematicData getSteering()
    {
        KinematicData steering = new KinematicData();
        steering._velocity = target.position - transform.position;
        if(steering._velocity.magnitude <= radius)
        {
            return null;
        }
        else
        {
            steering._velocity /= timetoTarget;
            steering._velocity.Normalize();
            steering._velocity *= maxspeed;
        }
        steering._rotation = Vector3.zero;
        return steering;
    }
}
