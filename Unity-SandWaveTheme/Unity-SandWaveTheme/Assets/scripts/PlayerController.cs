using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed = 1;

	public int curHealth;
	public int maxHealth;

	public bool isDoor;

	public Rigidbody2D rb2d;

	public float moveHorizontal = 0;
	public float moveVertical = 0;
	public bool enableMove = true;
	public int KeyCount;


	private Vector3 jumpAction;
	public float speedDirX;
	public float speedDirY;


	private Animator anim;
	private SpriteRenderer sprite;
	private Transform target;
	private GameObject LastPosition;
	private float DelayLandSeconds = 0.75f;
	//private float JumpSpeed = 0.75f;
	private bool bUncommittedJump;
	private ShotController DolphinSidearm;


	void Start(){
		
		rb2d = GetComponent<Rigidbody2D> ();
		curHealth = maxHealth;

	}		

	void OnTriggerEnter2D (Collider2D room)
	{

		
	}

	IEnumerator jump()
	{
		
		GetComponent<BoxCollider2D> ().enabled = false;
		// play animation.. //
		yield return new WaitForSeconds (DelayLandSeconds);
		GetComponent<BoxCollider2D> ().enabled = true;
		yield return null;

	}

	void FixedUpdate() {

		if (Input.GetButton ("Jump"))
		{

			StartCoroutine (jump ());

		}

		if (enableMove) {

			moveHorizontal = 0;
			moveVertical = 0;
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				moveVertical++;
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)){
				moveVertical--;
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				moveHorizontal++;
			}
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				moveHorizontal--;
			}
				

			//moveHorizontal = Input.GetAxis ("Horizontal");
			//moveVertical = Input.GetAxis ("Vertical");

			/*if (moveVertical < 0) {
				moveHorizontal = 0;
				anim.SetBool ("isWalkingForward", true);
				anim.SetBool ("isWalkingBack", false);
			} else if (moveVertical > 0) {
				anim.SetBool ("isWalkingBack", true);
				anim.SetBool ("isWalkingForward", false);
			} else {
				anim.SetBool ("isWalkingForward", false);
				anim.SetBool ("isWalkingBack", false);
				moveVertical = 0;
			}
			if (moveHorizontal < 0) {
				moveVertical = 0;
				anim.SetBool ("isWalkingSide", true);
				sprite.flipX = true;
			} else if (moveHorizontal > 0) {
				moveVertical = 0;
				anim.SetBool ("isWalkingSide", true);
				sprite.flipX = false;

			} else {
				anim.SetBool ("isWalkingSide", false);
				moveHorizontal = 0;
			}
			*/
			
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
			GetComponent<Rigidbody2D> ().velocity = movement * speed;

		} 
				
	}// void FixedUpdate() //

	void Die(){
		// Game Over screen

	}

	void Update()
	{
		
		if (curHealth > maxHealth)
		{
			
			curHealth = maxHealth;

		}

		if (curHealth <= 0)
		{
			
			Die ();

		}

	}// void update() //

}// class PlayerController //
