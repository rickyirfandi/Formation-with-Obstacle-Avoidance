using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlusArrive : MonoBehaviour
{

    /**

data kinematic : posisi dan orientasi pada karakter telah terdapat pada class transform
untuk mengakses gunakan transform
    **/


    //Transform charakter; // sudah tidak perlu karena sudah bisa diakses dengan syntax this.transform 
    public Transform _target;
    public float jari2;
    public Transform[] child;
    public bool[] assigned;
    public int _maxSpeed;
    public int _radius;
    public int _timeToTarget;
    public GameObject agen;

    void Start()
    {
        child = new Transform[this.transform.childCount];
        assigned = new bool[this.transform.childCount];
        for (int i = 0; i<child.Length; i++)
        {
            child[i] = this.transform.GetChild(i).transform;
            assigned[i] = false;
        }
        setChildPos();
        agen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //GLB
        //position = position + velocity
        this.transform.position = transform.position + getSteering()._velocity * Time.deltaTime;
     }

    public KinematicData getSteering()
    {
        KinematicData _KinematicOut = new KinematicData();
        _KinematicOut._velocity = _target.position - this.transform.position; //#direction

        if (_KinematicOut._velocity.magnitude < _radius) //jika di dalam radius velocity = 0; berhenti
        {
            _KinematicOut._velocity = Vector3.zero; //jika di dalam radius velocity = 0; berhenti
            _KinematicOut._rotation = Vector3.zero;
            return _KinematicOut;
         }

        _KinematicOut._velocity /= _timeToTarget; //agar datang sesuai waktu yg di tentukan 

        if (_KinematicOut._velocity.magnitude > _maxSpeed)
        {
            _KinematicOut._velocity = _KinematicOut._velocity.normalized; // normalize membuat resultan vektor = 1.
            _KinematicOut._velocity *= _maxSpeed;
        }
        //this.transform.eulerAngles = getNewOrientation(this.transform.eulerAngles, _KinematicOut._velocity); //rotation menggunakan euler angle
        _KinematicOut._rotation = Vector3.zero;
        return _KinematicOut;
    }

    public Vector3 getNewOrientation(Vector3 _currentOrientation, Vector3 _velocity)
    {
        //Make sure we have a velocity
        if (_velocity.magnitude > 0) //length didapat dri fungsi magnitude (mendapatkan resultan)
        {
            //Calculate orientation using an arc tangent of the velocity components.
            float radian = Mathf.Atan2(-_velocity.x, _velocity.z); //dalam radian
            //float angle = radian * (180/Mathf.PI);  // untuk mengganti ke angle
            Vector3 newOrientation = new Vector3(0, radian, 0);
            return newOrientation;
        }

        //Otherwise use the current orientation
        else
            return _currentOrientation;


    }
    void setChildPos()
    {
        //float x = jari2 * Mathf.Sqrt(2-2*Mathf.Cos(360/child.Length * Mathf.Deg2Rad));
		// Kotak
		//child[0].position = this.transform.position + new Vector3(jari2, 0, 0);
		//child[1].position = this.transform.position + new Vector3(jari2, 0, -jari2);
		//child[2].position = this.transform.position + new Vector3(0, 0, -jari2);
		//child[3].position = this.transform.position + new Vector3(0, 0, 0);

		//lingkaran
		//child[0].position = this.transform.position + new Vector3(jari2, 0, 0);
		//child[1].position = this.transform.position + new Vector3(-jari2, 0, 0);
		//child[2].position = this.transform.position + new Vector3(0, 0, jari2);
		//child[3].position = this.transform.position + new Vector3(0, 0, -jari2);

		//segitiga
		child[0].position = this.transform.position + new Vector3(jari2, 0, 0);
		child[1].position = this.transform.position + new Vector3(-jari2, 0, 0);
		child[2].position = this.transform.position + new Vector3(-jari2, 0, jari2);
		child[3].position = this.transform.position + new Vector3(-jari2, 0, -jari2);
    }






}
