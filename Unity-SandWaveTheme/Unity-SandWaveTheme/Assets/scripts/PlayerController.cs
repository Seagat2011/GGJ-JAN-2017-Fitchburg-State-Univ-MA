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
	public GameObject shot1;
	public GameObject shot2;
	public GameObject shot3;
	public GameObject shot4;
	public GameObject shot5;
	public GameObject shot6;
	public GameObject shot7;
	public GameObject shot8;


	public bool isD, isDR, isR, isUR, isU, isUL, isL, isDL;

	public float delay;
	public float dts, dts2;

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
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		curHealth = maxHealth;

	}		

	void OnTriggerEnter2D (Collider2D room)
	{

		
	}

	IEnumerator jump()
	{
		
		GetComponent<BoxCollider2D> ().enabled = false;
		anim.SetBool ("isJump", true);
		yield return new WaitForSeconds (DelayLandSeconds);
		GetComponent<BoxCollider2D> ().enabled = true;
		anim.SetBool ("isJump", false);
		yield return null;

	}
	IEnumerator attack (){
		anim.SetBool ("isAttack", true);
		dts = 0;

		if (isD == true) {
			Instantiate (shot7, gameObject.transform.position, shot7.gameObject.transform.rotation);
		} else if (isDR == true) {
			Instantiate (shot8, gameObject.transform.position, shot8.gameObject.transform.rotation);
		} else if (isR == true) {
			Instantiate (shot1, gameObject.transform.position, shot1.gameObject.transform.rotation);
		} else if (isUR == true) {
			Instantiate (shot2, gameObject.transform.position, shot2.gameObject.transform.rotation);
		} else if (isU == true) {
			Instantiate (shot3, gameObject.transform.position, shot3.gameObject.transform.rotation);
		} else if (isUL == true) {
			Instantiate (shot4, gameObject.transform.position, shot4.gameObject.transform.rotation);
		} else if (isL == true) {
			Instantiate (shot5, gameObject.transform.position, shot5.gameObject.transform.rotation);
		} else if (isDL == true) {
			Instantiate (shot6, gameObject.transform.position, shot6.gameObject.transform.rotation);
		} else {
			Instantiate (shot1, gameObject.transform.position, shot1.transform.rotation);

			Instantiate (shot3, gameObject.transform.position, shot3.gameObject.transform.rotation);

			Instantiate (shot5, gameObject.transform.position, shot5.gameObject.transform.rotation);

			Instantiate (shot7, gameObject.transform.position, shot7.gameObject.transform.rotation);

			yield return new WaitForSeconds (1);
		}
		yield return new WaitForSeconds (1.5f);

		anim.SetBool ("isAttack", false);
		dts = 0;
		yield return null;
	}

	void FixedUpdate() {
		dts += Time.deltaTime;
		dts2 += Time.deltaTime;

		if (Input.GetButton ("Jump"))
		{
			if (dts2 > delay) {
				dts2 = 0;
				StartCoroutine (jump ());
			}
		}

		if (Input.GetButton ("Fire3")) {
			if (dts > delay) {
				StartCoroutine (attack ());
			}
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
				
			isD = false;
			isDR = false;
			isDL = false;
			isU = false;
			isUL = false;
			isUR = false;
			isR = false;
			isL = false;

			if (moveVertical == 0 && moveHorizontal == 0) {
				anim.SetBool ("isWalking", false);
			} else {
				anim.SetBool ("isWalking", true);
			}



			if (moveVertical == 1 && moveHorizontal == 1) {
				anim.SetBool ("isUpSide", true);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", false);
				sprite.flipX = false;
				isUR = true;
			} else if (moveVertical == 1 && moveHorizontal == -1) {
				anim.SetBool ("isUpSide", true);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", false);
				sprite.flipX = true;
				isUL = true;
			} else if (moveVertical == -1 && moveHorizontal == -1) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", true);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", false);
				sprite.flipX = true;
				isDL = true;
			} else if (moveVertical == -1 && moveHorizontal == 1) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", true);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", false);
				sprite.flipX = false;
				isDR = true;
			} else if (moveVertical == 1 && moveHorizontal == 0) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", true);
				sprite.flipX = false;
				isU = true;
			} else if (moveVertical == -1 && moveHorizontal == 0) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", true);
				anim.SetBool ("isSide", false);
				anim.SetBool ("isUp", false);
				sprite.flipX = false;
				isD = true;
			} else if (moveVertical == 0 && moveHorizontal == -1) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", true);
				anim.SetBool ("isUp", false);
				sprite.flipX = true;
				isL = true;
			} else if (moveVertical == 0 && moveHorizontal == 1) {
				anim.SetBool ("isUpSide", false);
				anim.SetBool ("isDownSide", false);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isSide", true);
				anim.SetBool ("isUp", false);
				sprite.flipX = false;
				isR = true;
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
