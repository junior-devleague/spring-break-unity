using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;
	//We'll be using a new keyword called "static" in this script.
	//"Static" means that a variable or method belongs to the whole class, not just an individual instance.
	//This means two things: one, that we can access it without needing a reference to a specific ScoreManager object,
	//and two, that this variable belongs to all ScoreManagers that are in this scene.
	//This is why we haven't been using "static" on the player and enemies: because we want each of those to have its own properties.
	//It would be a really boring game if killing one enemy also killed all the others in the scene.

	public static ScoreManager instance;
	//However, we also want an instance of this specific ScoreManager. 
	//Since we know there's only going to be one in any given scene, this works fine.
	//We need this further down in our script.

	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		score = 0;
		instance = this;
		//When we start our scene, we set our instance to refer to "this".
		//"This" refers to the instance that's running the function. 
		//Since we only have one ScoreManager in the scene, that ScoreManager component is what will be held in "this".
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
		//This makes sure that the score being displayed is constantly up-to-date.
		//The Text's text property gets reset every frame to this new string.
	}

	public static void AddToScore(int amount) {
		instance.StartCoroutine (ScoreCounter(amount));
		//This is why we needed an instance stored earlier. A coroutine needs an instance in order to run.
		//Coroutines are a way of doing an action in small parts over time, instead of all at once.
		//Using a coroutine here lets us watch our score count up from its previous value to its new value, instead of happening all at once.
	}

	static IEnumerator ScoreCounter(int count) {
		//A Coroutine is a function that returns an enumerator.
		//An enumerator allows us to go over something with multiple pieces of data, like we do with arrays.
		//Basically, a coroutine breaks down the progress of the function into pieces, and a little bit is run every frame.
		WaitForSeconds delay = new WaitForSeconds (1f / count);
		//The WaitForSeconds is how many chunks the function will be broken into.
		//By making it 1 divided by our count, our score counts up completely over the course of a second.
		for (int i = 0; i < count; i++) {
			score++;
			yield return delay;
			//"Yield" tells the coroutine to slice the input here.
			//"delay", our WaitForSeconds variable, tells Unity how long to wait before doing the next part.
		}
	}
}
