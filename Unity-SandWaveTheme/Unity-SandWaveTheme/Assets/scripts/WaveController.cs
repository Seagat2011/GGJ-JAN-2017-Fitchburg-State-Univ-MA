using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {
	
	public float speed;

	public float movehorizontal;
	public float movevertical;

	public Rigidbody2D rbWave;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (WaveLifeSpan ());
		rbWave = GetComponent<Rigidbody2D> ();


	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		

		Vector3 movement = new Vector3 (movehorizontal, movevertical, 0.0f);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;

	}

	IEnumerator WaveLifeSpan() {
		yield return new WaitForSeconds (10f);
		Destroy (this.gameObject);
		yield return null;
	}

}
