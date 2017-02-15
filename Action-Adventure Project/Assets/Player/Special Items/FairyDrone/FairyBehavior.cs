using UnityEngine;
using System.Collections;

public class FairyBehavior : MonoBehaviour {

	public float speed = 5.0f;
    public float returnTime = 4.0f;
	public Transform rotateTarget;
	public float rotateSpeed = 10.0f;
	private Transform player;
	private float moveH;
	private float moveV;
	private Vector3 moveDir;
	private bool canMove = true;
	public CharacterController controller;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		//ControlPlayer ();
		float moveH = Input.GetAxisRaw ("Horizontal");
		float moveV = Input.GetAxisRaw ("Vertical");
		if (canMove) {
			moveDir = new Vector3 (moveH, 0, moveV).normalized;
			controller.Move (moveDir * speed * Time.deltaTime);
			if (moveH != 0 || moveV != 0) {
				transform.rotation = Quaternion.LookRotation (moveDir);
			}


			if (Input.GetButtonUp ("Fire2")) {
				canMove = false;
				gameObject.GetComponent<Collider>().enabled = false;
				Invoke ("KillMe", 0.5f);

			}
		} 

		if (!canMove) {
			//rapidly move back to player
			Vector3 startingPos = this.transform.position;
			transform.position = Vector3.Lerp(startingPos, player.position, returnTime * Time.deltaTime);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTarget.rotation, rotateSpeed);
			//transform.position = Vector3.MoveTowards(, player.position, speed * Time.deltaTime); //it works but lets try for a smoother mvoe over time with interpolated speed
		}
	}

	void KillMe (){
        player.SendMessage("MoveAgain");
	    Destroy (this.gameObject);
	}
}	