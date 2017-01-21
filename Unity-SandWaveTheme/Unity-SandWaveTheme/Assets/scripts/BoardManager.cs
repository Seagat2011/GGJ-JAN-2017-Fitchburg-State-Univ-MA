using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class BoardManager
{
	public void SetupScene()
	{
		
		//Instantiate the scene
		BoardSetup ();

	}

	private void BoardSetup ()
	{
		
		// TODO //

		//Reset our list of gridpositions.

		//Instantiate a random number of obstacle tiles based on minimum and maximum, at randomized positions.

		//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.

		//Instantiate a number of enemies based on current level number, based on a logarithmic progression.

		//Instantiate a number of waves based on current level number, based on a logarithmic progression, at corner positions.

		//Instantiate a random number of enemies based on minimum and maximum, at cornder positions.

	}

	//Update is called at interval.
	void Update()
	{

	}

}//class BoardManager//

