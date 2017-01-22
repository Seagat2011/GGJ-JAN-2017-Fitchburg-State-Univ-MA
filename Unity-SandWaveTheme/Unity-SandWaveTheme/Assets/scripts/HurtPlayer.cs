using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	public PlayerController player;

	public int dmg = 1;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		//GameObject.Find finds the name of gameobject not tag.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			player.curHealth -= dmg;
			StartCoroutine (FlashRed ());
		}
	}

	IEnumerator FlashRed() {
		player.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		player.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
		player.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		player.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return null;
	}

}
