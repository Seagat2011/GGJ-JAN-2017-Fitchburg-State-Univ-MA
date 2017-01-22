using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float speed;

	public float movehorizontal;
	public float movevertical;
	public float fShotLifeSpan = 4.0f;

	public Rigidbody2D rbShot;

	// Use this for initialization
	void Start ()
	{
		
		StartCoroutine (SqueezeDolphin ());
		rbShot = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		
		Vector3 movement = new Vector3 (movehorizontal, movevertical, 0.0f);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;

	}

	IEnumerator SqueezeDolphin() {
		
		yield return new WaitForSeconds (fShotLifeSpan);
		Destroy (this.gameObject);
		yield return null;

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}

}
