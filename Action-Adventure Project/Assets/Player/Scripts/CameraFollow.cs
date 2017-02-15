using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float cameraX = 0f;
	public float cameraY = 10f;
	public float cameraZ = 10f;
	//private Camera mainCamera;
	public GameObject player;

	// Use this for initialization
	void Start () {
		//mainCamera = GetComponent<Camera>();
		//player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		Vector3 playerInfo = player.transform.transform.position;
		//mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
		this.transform.position = new Vector3 (playerInfo.x, playerInfo.y + cameraY, playerInfo.z - cameraZ);
	}
}