﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1;
	public float moveHorizontal;
	public float moveVertical;
	public float transformXthresh = 0.2f;
	public float transformYthresh = 0.2f;
	public bool CannotMove = false;

	public Transform target;

	private Rigidbody2D rbEnemy;
	private Animator anim;
	private SpriteRenderer sprite;

	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		rbEnemy = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag("Player").transform;

	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Player") {
			
			CannotMove = true;

		}

	}

	// get this idiot walking around
	public void MoveEnemy()
	{
		//assign target for enemy to follow.
		int xDir = 0;
		int yDir = 0;

		if (Mathf.Abs (target.position.x - transform.position.x) > 0.2f) {
			
			xDir = target.position.x > transform.position.x ? 1 : -1;

		} else {
			
			yDir = target.position.y > transform.position.y ? 1 : -1;

		}
		if (Mathf.Abs (target.position.y - transform.position.y) > 0.2f) {
			
			yDir = target.position.y > transform.position.y ? 1 : -1;

		} else {
			
			xDir = target.position.x > transform.position.x ? 1 : -1;

		}

		//convert movement varibles from target varibles
		moveHorizontal = xDir;
		moveVertical = yDir;

		//movement controls
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement * speed;

	}// void MoveEnemy() //
		
	void FixedUpdate() {
			
		MoveEnemy ();

		if (moveVertical == 1 && moveHorizontal == 0) {
			anim.SetBool ("isDiag", false);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", true);
			sprite.flipX = false;
			sprite.flipY = false;
		} 
		if (moveVertical == -1 && moveHorizontal == 0) {
			anim.SetBool ("isDiag", false);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", true);
			sprite.flipX = false;
			sprite.flipY = true;
		} 
		if (moveHorizontal == 1 && moveVertical == 0) {
			anim.SetBool ("isDiag", false);
			anim.SetBool ("isSide", true);
			anim.SetBool ("isForward", false);
			sprite.flipX = false;
			sprite.flipY = false;
		} 
		if (moveVertical == -1 && moveVertical == 0) {
			anim.SetBool ("isDiag", false);
			anim.SetBool ("isSide", true);
			anim.SetBool ("isForward", false);
			sprite.flipX = true;
			sprite.flipY = false;
		} 
		if (moveVertical == 1 && moveHorizontal == 1) {
			anim.SetBool ("isDiag", true);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", false);
			sprite.flipY = false;
			sprite.flipX = false;
		} 
		if (moveVertical == -1 && moveHorizontal == 1) {
			anim.SetBool ("isDiag", true);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", false);
			sprite.flipY = true;
			sprite.flipX = false;
		} 
		if (moveVertical == 1 && moveHorizontal == -1) {
			anim.SetBool ("isDiag", true);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", false);
			sprite.flipX = true;
			sprite.flipY = false;
		} 
		if (moveVertical == -1 && moveHorizontal == -1) {
			anim.SetBool ("isDiag", true);
			anim.SetBool ("isSide", false);
			anim.SetBool ("isForward", false);
			sprite.flipX = true;
			sprite.flipY = true;
		} 


	}

}// class EnemyController //