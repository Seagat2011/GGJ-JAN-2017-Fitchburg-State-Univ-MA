using UnityEngine;
using System.Collections;

// Wave(); Enemy() spawning utility //
public class Spawner : MonoBehaviour {

	//private WaveController SpikeVel;
	public float Delay;
	public float delayTimeStamp;
	public GameObject WavePrefab;

	public float DelaySeconds = 2;
	public float moveHorizontal = 0;
	public float moveVertical = 0;
	public float rotation = 0;

	// Use this for initialization
	void Start ()
	{
		
		delayTimeStamp = 0;
	

	}

	void Update()
	{
		
		delayTimeStamp += Time.deltaTime;

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		
		if (delayTimeStamp > Delay)
		{
			StartCoroutine (shoot ());
			delayTimeStamp = 0;

		}

	}

	IEnumerator shoot(){

		Instantiate(WavePrefab, gameObject.transform.position, Quaternion.identity);
		yield return new WaitForSeconds (DelaySeconds);
		yield return null;

	}

}// class Spawner //
