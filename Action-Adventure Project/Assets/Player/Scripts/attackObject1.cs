using UnityEngine;
using System.Collections;

public class attackObject1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("KillMe", 0.5f); //executes command after specified seconds. we'll mess with this later
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	

	void KillMe() {
		Destroy (this.gameObject);
	}

}
