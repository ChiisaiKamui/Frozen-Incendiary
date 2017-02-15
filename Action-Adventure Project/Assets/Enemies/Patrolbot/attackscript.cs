using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour {
    public GameObject facing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            Debug.Log("hit");
            other.gameObject.SendMessage("AddImpact", facing.transform.forward);
        }
    }
}
