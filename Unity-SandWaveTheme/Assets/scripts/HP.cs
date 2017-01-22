using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP : MonoBehaviour {

	public PlayerController player;
	public Image HP0, HP1, HP2, HP3, HP4, HP5, HP6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.curHealth < 7) {
			HP6.enabled = false;
		}
		if (player.curHealth < 6) {
			HP5.enabled = false;
		}
		if (player.curHealth < 5) {
			HP4.enabled = false;
		}
		if (player.curHealth < 4) {
			HP3.enabled = false;
		}
		if (player.curHealth < 3) {
			HP2.enabled = false;
		}
		if (player.curHealth < 2) {
			HP1.enabled = false;
		}
		if (player.curHealth < 1) {
			HP0.enabled = false;
		}
	}
}
