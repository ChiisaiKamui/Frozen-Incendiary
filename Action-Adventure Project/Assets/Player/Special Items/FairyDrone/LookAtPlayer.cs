using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}
