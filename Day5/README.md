#Day 5

###Topics and Goals
By the end of today's lesson, students should be able to...
- Import and use assets.
- Create AnimationClips.
- Use the Animation Controller to make a character animate in response to its scripted behavior.
- Import sounds and background music into a project.

####Importing and using assets
You can access the Asset Store from within Unity and download directly from there. Go to Window -> Asset Store and a tab will open in your editor. You can search using the searchbar, but you cannot paste links directly. To make things easier, you can sign into your Unity account in the browser and add assets to your wish list from there, and then access them from within the editor. Once you download, Unity will automatically extract them into your current project. Some assets are paid, though there are plenty of free assets available. We've found some for you already in the Resources section of this page.

####Animating a Character
Import the Mr. RabZ character first. Inside the Mr. RabZ folder, you should see a folder called "Models". Select the one named "rabbit" and add it to your scene. He comes with one component already attached - an Animator.

Copy all of the components from your Player and paste them onto the rabbit. Make sure you haven't forgotten any public variables or the ParticleSystem child object.

Now, open up the Animator tab in the editor and select Mr. RabZ in the Hierarchy. You should see a few states already created, and a parameter "Speed" already defined. If you look at the connection between "Idle" and "Walk", you'll see that it will change from "Idle" to "Walk" when Speed is greater than 0.1.  The connection from "Walk" to "Idle" is the same but reversed.

Unfortunately, the Animator doesn't know to change that variable automatically. We need to change our MovePlayer script to interact with the Animator and tell it what our speed is.

In MovePlayer, create an Animator variable and assign it to this object's Animator. Check the magnitude (strength) of our movement Vector3. If it is less than 0.01, tell the animator to set the float variable "Speed" to 0.0. Otherwise, if the character is moving, set "Speed" to how fast it's going.

Test your game and make sure you see the character walking. If he is walking too slowly, you can change the animation play speed by clicking on that state in the Animator tab and changing the Speed property in the Inspector.

Now it's time to do it yourself. The Mr. RabZ character also comes with a Jump animation, but the logic of when to play it is not set up for you. Create a Trigger parameter called "IsJumping".

Now create two-way connections between "Idle" and "Jump" and "Walk" and "Jump". Make the condition for Idle -> Jump the "IsJumping" parameter, and the same for Walk -> Jump.

Then, edit PlayerMove to set the trigger for "IsJumping" in your jump function.

####Creating your own AnimationClip

Now that you've used an Animator, you can make your own clips. We're going to make a Text element that tells the player they've either won or lost, and it will fade in smoothly.

####Completing a level

We need a situation to play the animation we just made. Attach a script called "LevelOverManager" to the Text element. It should include a reference to your Animator and two public static methods, "WinLevel" and "LoseLevel".

Once it's done, you can call LevelOverManager.WinLevel() from your Goal script, and LevelOverManager.LoseLevel() from PlayerHealth when the player dies.

You can now create a start menu. Create a new empty scene with a Button element. Attach a script called StartGame to it, with a public method StartGame that will load scene 1 when pressed. Assign this method as the action for clicking this button. Save this scene as StartMenu.unity.

Now, go to File -> Build Settings. Select "Add Open Scenes". You'll see StartMenu as Scene 0. You can now switch back to the scene you were working on and repeat these steps to make it Scene 1.

Finally, create another empty scene. Give this one a text element telling the player "You Won!". Then add it as Scene 2. This is so that winning the level doesn't crash the game. You can always add more levels on your own.

####Adding sound

First, download the sounds provided. A jump sound, an explosion sound, and a background track are included.

Make an Audio folder in your project's assets folder. Import these audio files into your Unity project here.

Let's add background music first. In your Environment, attach an AudioSource and give it the background music clip. We want Looping and Play On Awake to be on. That means it will start playing at the beginning of the scene and keep playing forever.

To make an object play sound effects, the process is similar. Place an AudioSource component on the player character. Set its Clip to the jump sound you just imported. Make sure Looping and Play On Awake are both disabled.

Then, in MovePlayer, include a reference to your AudioSource and tell it to Play when the character jumps.

Use the same process to make the enemy play the explosion sound when it takes damage.

###Resources
We have selected three asset packages from the Unity Asset Store which are free to download. In consideration of this, these assets will not be uploaded here but linked below to download from the Asset Store directly. Please support the original creators by leaving them a review if possible.
- [Mr. RabZ](https://www.assetstore.unity3d.com/en/#!/content/15897) 3D cartoon rabbit with animations
- [Pixel Cube World Atlantis](https://www.assetstore.unity3d.com/en/#!/content/65665) Collection of Minecraft-like terrain cubes
- [Low Poly Environment Pack](https://www.assetstore.unity3d.com/en/#!/content/62304) Collection of cube-based tree models

Two sound effects and one background music file are included in this repository. These audio files are licensed under the Creative Commons 0 License, meaning they are for all intents and purposes in the public domain.