using UnityEngine;
using System.Collections;

//"Using" tells your script that you want to use the Unity Engine. 
//Without this line, your script won't know what any of the Unity components are.
//Unity puts these lines here for you automatically.
//System.Collections allows you to access some extra data types C# uses for lists and groups of objects. 
//We won't be using these in this script, but some Unity components need them to work.

public class MovePlayer : MonoBehaviour {
	//When you make a script, Unity automatically gives you the above line.
	//This tells Unity that your script is a type of MonoBehaviour (note the British spelling!)
	//MonoBehaviours are scripts which come with some built-in function names that Unity knows
	//to call automatically at certain points in your game.

	Rigidbody rb;
	//Before we make any functions, we declare our variables here.
	//Declaring a variable just means giving it a type to hold. 
	//Here, I've stated that "rb" can only hold a Rigidbody. 
	//If I try to put anything that's not a Rigidbody in this variable, it will give me an error.

	Vector3 movement;
	//We'll need a Vector3 to hold the x, y and z positions of our object when we move it.

	float h, v;
	//If you have multiple variables of the same type, you can declare them on one line like this.
	//Both "h" and "v" are floats.

	public float speed = 4.0f;
	//There's two new things here: "public" in front of a declaration lets us access this variable from our Editor.
	//It also lets us access this value from another script--like if we made a powerup that makes you faster.
	//If you go back to the Unity Editor and look at the MovePlayer component, you'll see a field for Speed.
	//You can change this value in the Editor to be anything you like.
	//The second part is that I initialize it to a default value, 4.0f. (The f tells it that this is a float number.)
	//That way, if you forget to set a value in the Editor, the script will use this value instead.
	//The value you set in the editor takes priority over the default value.

	public float jumpPower = 160f;
	//We do the same for Jump Power. This is a much larger number since we need it to be able to overcome gravity.



	//An empty Start function is provided for you automatically.
	//You can put anything you want this script to do at the start of your level in here.
	//This is best used to initialize your variables. Unity won't know about the other parts of your game object
	//unless you tell it about them.
	void Start () {
		//We tell Unity about other components attached to our GameObject using GetComponent<type>().
		//So, since we need to get the object's Rigidbody in order to move it, we do that here.
		rb = GetComponent<Rigidbody>();
	}
	
	//Unity also gives us an Update function automatically.
	//Update runs every time anything on the screen changes. 
	//Most games run at around 60 frames per second, so this means Update usually runs 60 times every second.
	//However, this depends on how fast your computer is, what else is on the screen at the same time, and other factors.
	//This makes it fast and good for animations and text, but not good when you need consistent change over time, like moving characters.
	//It might run more than 60 frames per second, or it might run less, and lag your game.
	//So we don't want to use Update() for moving objects around, since it doesn't run at a fixed, consistent rate.
	//We want to be using FixedUpdate instead. This method always runs exactly 60 times a second.
	void FixedUpdate () {
		h = Input.GetAxis ("Horizontal");
		//What this is doing is putting the directional input from the player into the variable h.
		//Unity's input module lets you define an axis: a pair of keys that affect a value positively or negatively.
		//The horizontal axis is, directionally, left and right.
		//Moving right means you're traveling forward along the x-axis, like on a graph. So, right gives us a positive horizontal value.
		//Left means you're moving backwards along the x-axis, and left gives us a negative horizontal value.
		//Some keyboards don't have arrow keys, and some people prefer to use W, A, S and D to handle movement in PC games.
		//The "Horizontal" axis lets us define as many pairs of keys as we want to do the same function.
		//So, doing it this way lets you use "D" or "right arrow" to move right, and "A" or "left arrow" to go left.
		//And if you were to use a controller to play your game, Unity would know that the d-pad or joystick does the same thing as your keys.

		v = Input.GetAxis ("Vertical");
		//The same happens for v. Pressing "w" or "up arrow" gives us a positive value, and "s" or "down arrow" gives us negative.
		//GetAxis gives us a value betwen -1.0 and +1.0. When it is 0, that means we are not moving along that axis at all.

		Move (h, v);
		//Here, we call a function we will write ourselves. 
		//We take the input we just read from the player's keyboard or controller, and move our character with it.

		if (Input.GetButtonDown("Jump")) {
			//We have the player jump if they press the Jump button. Unity defaults this to the Spacebar.
			//Instead of a number, GetButtonDown gives us "true" or "false". 
			//We can use an if-statement to do an action only when it is true (the button is pressed).
			//Without this if-statement, the player would constantly be jumping!
			Jump ();
		}
	}

	void Move(float h, float v) {
		//This function takes two parameters. Parameters are data you give to a function that it uses to do its job.
		//Like with declaring variables, when we make a function we have to tell it what type of data it needs those parameters to be.

		movement.Set(h, 0, v);
		//We can't use raw floats to change our object's position. Unity doesn't know where those floats get added to.
		//We have to use our Vector3 to tell it where to put them.
		//We want our horizontal movement to move us left and right, along the X-axis, so we put it in the first slot.
		//We don't want to move up and down using the keyboard. We'll make a separate function to Jump using a button.
		//So we set the Y-axis to 0.
		//We want the up and down keys to move us forward and back, so we put their value in the Z-axis's slot.

		rb.AddForce(movement * speed, ForceMode.VelocityChange);
		//Once we have our input stored in "movement", we can use it to move our object.
		//First, we access its Rigidbody. This is how we move objects realistically so they can bump into things and interact with the world.
		//Then, we add force to it, to "push" it in the direction we want.
		//Since we know h and v will be between -1.0 and +1.0, we multiply the input by our speed so it will move as fast as we want it to.
		//Finally, we tell it the type of force we're applying.
		//We use VelocityChange to tell the Rigidbody to change its velocity.
		//It will stop whatever it's doing and change directions as soon as the input changes.
		//This makes it quick and responsive--we don't have to wait for it to build up speed.
		//So it's the best choice for controlling our player here.

		Vector3 newVelocity = Vector3.ClampMagnitude (rb.velocity, speed);
		//Then, we need to tell it not to go faster than its maximum speed.
		//By using ClampMagnitude, we take our Rigidbody's current Velocity, and chop off anything that exceeds our Speed value.
		//This keeps its speed at a constant maximum while it's moving.
		//If we didn't do this, we'd see out player rocket off into the distance and we could no longer see or control it!

		//We have to keep the y-velocity from our Rigidbody's last state, so that gravity affects it properly.
		newVelocity.y = rb.velocity.y;

		//Finally we set its velocity to the new value.
		rb.velocity = newVelocity;

		//Now we need to have the character look where it's going.
		//We need to see if our input is zero on both axes, and only rotate when that is not true.
		//However, h and v are floats. Computers don't know what to do with numbers with decimal points, and can't compare them precisely.
		//If we try to check if h == 0, it doesn't always work, since it might see something like 0.0000001.
		//However, there's a trick we can use.
		if (movement.sqrMagnitude > 0.001) {
			
			rb.MoveRotation(Quaternion.LookRotation(movement));
			//Quaternion.LookRotation gives us a rotation that turns the object so its forward direction is pointing at the direction given.
			//We use MoveRotation to apply that rotation to our character.

		}
	}

	public bool isGrounded() {
		//Here we check if the player is on the ground.
		//Notice that this function starts with "bool" instead of "void".
		//This tells us that type of value this function must return to us when we run it.
		//"Void" means "nothing", so we don't expect void functions to give us any data back.
		//A return type of "bool" means that this will give us either "true" or "false" when we run it.

		Vector3 centerPoint = transform.position;
		//We store our current position.
		centerPoint.y += 1f;
		//On this new position, we set the y-value to a little bit above the ground.
		//That way, we can check if the ground is below this point.

		return Physics.Raycast(centerPoint, -Vector3.up, 1.1f);
		//A Raycast is a tool you can use here to check if there is ground below you.
		//There are several ways to do a Raycast, and you may need to look at the Unity docs to know which one is right for your situation.
		//Here, this raycast takes a start point, a direction, and a distance.
		//Remember, up and down are positive and negative on the y-axis, so saying "negative up" is the same as "down".
		//So, this tells us to start at the player's position (the center between its feet), and go down.
		//This Raycast will return True if it hits anything from its start to its maximum length.
		//We make the length a little bit longer than it is high above the ground.
		//So, we can use it to see if there's ground right underneath our feet. If we are too high up, we are not grounded anymore.
	}

	void Jump() {
		//The player is only allowed to jump if they are on the ground.
		if(isGrounded()) {

			rb.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
			//Jump is similar to Move. Here, we use a Vector3 shorthand to tell us where we're going.
			//Vector3.up is the same as making a Vector3 with the values: (0, 1.0f, 0)
			//This tells us to move forward along the Y-axis, which means we're going up.
			//We also use ForceMode.Impulse to tell it to apply the entire jump force at once.
			//This is why we made jumpPower a much larger number than our speed.
			//With upwards movement, we are fighting against gravity, and also how heavy our Rigidbody is.
		}
	}
}
