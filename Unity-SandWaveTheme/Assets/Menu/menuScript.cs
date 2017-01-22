using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;
using UnityEngine.SceneManagement; // neded in order to load scenes

public class menuScript : MonoBehaviour 
{
	
	public Canvas quitMenu;


	public Button startText;
	public Button exitText;
	public Button controlText;
	//public Image Diver;


	void Start ()



	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		//Diver.enabled = true;
		Cursor.visible = true;

	}

	public void ExitPress() //this function will be used on our Exit button

	{
		
		quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
		startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;
		//Diver.enabled = false;







	}




	public void ControlPress() //this function will be used on our Exit button

	{
		
		quitMenu.enabled = false; //enable the Quit menu when we click the Exit button
		startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;
		//Diver.enabled = true;



	}
	public void NoPress() //this function will be used for our "NO" button in our Quit Menu

	{
		quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;
		//Diver.enabled = true;


	}

	public void StartLevel () //this function will be used on our Play button

	{
		SceneManager.LoadScene (1); //this will load our first level from our build settings. "1" is the second scene in our game

	}


	public void StartReturn() //this function will be used on our Play button

	{
		SceneManager.LoadScene (3); //this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void Controls () //this function will be used on our Play button

	{
		SceneManager.LoadScene (2); //this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu

	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game

	}

	public void Backstory () //This function will be used on our "Yes" button in our Quit menu

	{
		SceneManager.LoadScene (4); //this will quit our game. Note this will only work after building the game

	}

	public void Credits () //this function will be used on our Play button

	{
		SceneManager.LoadScene (7); //this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void story () //This function will be used on our "Yes" button in our Quit menu

	{
		SceneManager.LoadScene (8); //this will quit our game. Note this will only work after building the game

	}


}