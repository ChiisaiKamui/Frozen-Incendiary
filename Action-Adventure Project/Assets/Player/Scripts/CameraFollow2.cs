using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {
	public Transform target;
    //private Transform player;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards (transform.position, target.position, step);
        transform.position = Vector3.Lerp(transform.position, target.position, step);
        //transform.LookAt(player);
	}
}