using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

	//var for navigation
	public Transform[] navPoints;
	public float navPointDistance = 0.5f;
	private int destPoint = 0;
	private float waitTimer = 0.0f;
	public float waitTime = 2.0f;
	public UnityEngine.AI.NavMeshAgent agent;

	//var for player detection
	public GameObject player;
	public Collider playerColl;
	public GameObject pointing;
	public Camera cammy;
	private Plane[] planes;

	void Start () {
		//agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//agent.autoBraking = false; //optional. False prevents slowing as you near a point
		GoToNextPoint();
	}
    	

	void Update () {
		planes = GeometryUtility.CalculateFrustumPlanes (cammy);
		if (GeometryUtility.TestPlanesAABB (planes, playerColl.bounds)) {
			//Debug.Log ("Player detected");
			CheckForPlayer ();
		}
		else if (agent.remainingDistance < navPointDistance/* && waiting == false*/) {
            waitTimer += Time.deltaTime;
            if (waitTimer>= waitTime)
            {
                GoToNextPoint();
            }
        }
	}
    void GoToNextPoint(){
		if (navPoints.Length == 0) {
			return;
		}
		agent.destination = navPoints[destPoint].position;
		destPoint = (destPoint + 1) % navPoints.Length;
        waitTimer = 0;
	}
	void CheckForPlayer() {
		RaycastHit hit;
		Debug.DrawRay (pointing.transform.position, pointing.transform.forward * 5, Color.green);
		if (Physics.Raycast (pointing.transform.position, transform.forward, out hit, 5)) {
			//Debug.Log ("Player found");
			agent.destination = player.transform.position;
		}
        else
        {
            waitTimer = 0;
        }
	}

	void OnCollisionEnter(Collision collision){
        Debug.Log("collided");
        if (collision.transform.tag == "player") {
			collision.gameObject.SendMessage ("AddImpact", Vector3.forward);
		}
	}
}