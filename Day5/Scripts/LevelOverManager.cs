using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelOverManager : MonoBehaviour {

	static Animator anim;
	Text text;
	static string message;
	static bool loadNextScene;
	//Are we ready to load the next scene?
	static int nextSceneIndex;
	//Which scene will we load?
	float delay = 1f;
	float timer = 0f;

	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
		text = GetComponent<Text> ();
		message = text.text;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = message;
		if (loadNextScene) {
			//If we're ready to load...
			timer += Time.deltaTime;
			//Start the timer
			if (timer >= delay) {
				//When the timer is done, load the scene by its index number.
				SceneManager.LoadScene (nextSceneIndex);
				//Set it back to false in case something goes wrong and it tries to load more than once.
				loadNextScene = false;
			}
		}
	}

	public static void WinLevel() {
		message = "Level Complete!";
		//Set our message to the appropriate text.
		loadNextScene = true;
		//Show that we're ready to load the next scene.
		nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		//Which scene are we loading?
		//Since this level is complete, we're going to get its index and add 1 to go to the next scene in order.
		//So, if we're on Level 1, it knows to load Level 2.
		anim.SetTrigger ("LevelOver");
		//Finally, tell our animation to play.
	}

	public static void LoseLevel() {
		message = "Game Over!";
		loadNextScene = true;
		nextSceneIndex = 0;
		//Since this is game over, we'll set our next scene to Scene 0, which is the first scene in our Build Order.
		//If you've added a main menu that appears at the start of the game, that's where this will take you.
		anim.SetTrigger ("LevelOver");
	}
}
