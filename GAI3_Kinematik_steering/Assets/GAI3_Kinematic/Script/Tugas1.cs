using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tugas1 : MonoBehaviour {
	public Transform _target;
	public int _maxAcceleration;
	public int _maxSpeed;
	public Vector3 _velocity = Vector3.zero;
	//extra
	//public Text test;
	public int _radius;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//test.text = "" + _velocity.magnitude;
		if (getSteering ()._linear.magnitude == 0) {
			_velocity = Vector3.zero;
		}
		this.transform.position += _velocity * Time.deltaTime;
		_velocity += getSteering ()._linear * Time.deltaTime;
		if (_velocity.magnitude > _maxSpeed) {
			_velocity.Normalize ();
			_velocity *= _maxSpeed;
		}
	}
	public SteeringData getSteering(){
		SteeringData _SteeringOut = new SteeringData ();
		_SteeringOut._linear = this.transform.position - _target.position;
		if (_SteeringOut._linear.magnitude > _radius*1.49) {
			_SteeringOut._linear = Vector3.zero;
			return _SteeringOut;
		}
		if (_SteeringOut._linear.magnitude > _radius) {
			_SteeringOut._linear.Normalize ();
			_SteeringOut._linear *= _maxAcceleration * -1;
			_SteeringOut._angular = Vector3.zero;
			return _SteeringOut;
		}
		_SteeringOut._linear.Normalize ();
		_SteeringOut._linear *= _maxAcceleration;
		_SteeringOut._angular = Vector3.zero;
		return _SteeringOut;
	}
}
