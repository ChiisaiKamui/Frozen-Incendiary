using UnityEngine;
using System.Collections;

public class PlayerControls1 : MonoBehaviour {

	//var for player movement
	public float speed = 4.0f;
	private float moveH;
	private float moveV;
	private Vector3 moveDir;
	private bool canMove = true;
	private CharacterController controller; //consider switching the whole thing to rigidbody. Going to want to do knockback

	//var for knockback on hit
	public float mass = 3.0f;
	private Vector3 impact = Vector3.zero;
	public float force = 10f;	//temporary variable. To be removed when I figure out the AddImpact better 


	//var for player items
	public GameObject attackObject;
	public GameObject fairy;
	public GameObject fairySpawn;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//ControlPlayer ();
		float moveH = Input.GetAxisRaw ("Horizontal");
		float moveV = Input.GetAxisRaw ("Vertical");
		if (canMove) {
			moveDir = new Vector3 (moveH, 0, moveV).normalized;
			//controller.Move (moveDir * speed * Time.deltaTime);
			controller.SimpleMove (moveDir * speed);
			if (moveH != 0 || moveV != 0) {
				transform.rotation = Quaternion.LookRotation (moveDir);
			}
		

			if (Input.GetButtonDown ("Fire1")) {
				Attack ();
				canMove = false;
				Invoke ("MoveAgain", 0.5f); //altogether this will render the player motionless for the same length of time as the existence of the attackObject. if one changes, the other must as well
			}

		} //we can make this canMove section better. maybe something where as long as it exists (while command) the attackObject messages this script to keep forcing canmove to be false
		//this would enable multiple attacks before effect completes
		//maybe also setting up a resetable wait timer, but that's going to be a pain in the ass

		//applies impact force
		if (impact.magnitude > 0.2F) {
			controller.Move (impact * Time.deltaTime);
			// consumes the impact energy each cycle:
			impact = Vector3.Lerp (impact, Vector3.zero, 5 * Time.deltaTime);
		}


		if (Input.GetButtonDown ("Fire2") && controller.isGrounded) {
			canMove = false;
			MakeFairy();
		}
		/*else if (Input.GetButtonUp ("Fire2")) {
			MoveAgain();
		}*/	
	}

	//we'll probably wrap this into the same function for when we take damage 
	public void AddImpact (Vector3 dir/*, float force*/) {
		//Vector3 dir = Vector3.forward * -1;
		dir.Normalize();
		if (dir.y < 0) {
			dir.y = -dir.y;
		}// reflect down force on the ground
		impact += dir.normalized * force / mass;
	}

	//this attack line should ultimately call an animation, but for now we'll use it to instantiate a simple attack block
	void Attack () {
		Instantiate (attackObject, transform.position + (transform.forward), transform.rotation);
	
	}

	void MakeFairy () {
		Instantiate (fairy, fairySpawn.transform.position, fairySpawn.transform.rotation);
	}

	void MoveAgain () {
		canMove = true;
	}

}
