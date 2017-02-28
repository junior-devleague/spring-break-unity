#Day 1

###Topics and goals
By the end of this lesson, students should be able to...
- Understand the basics of the Unity editor.
- Understand the basics of writing scripts in C#.

###Intro to the Editor

When you open up the Unity program, you'll see a splash screen like this one:

Create a new project and give it a name. When you click "Create Project", it'll open a screen that looks similar to this one:

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/editor.png)

Yours might not look exactly like this one. Unity comes with a few different layouts, and the one pictured here is the 2 by 3 layout. Just go to Window -> Layouts -> 2 by 3 to switch it over. You can drag elements around and put them wherever.

The tabs shown here should be the default ones. It's a good idea to have these five tabs open at all times:

####The Scene View
The scene view is the view of your scene, or level. You can rotate around and zoom in or out to look at and adjust anything in the scene. The scene view, and the rest of Unity, use the 3D coordinate system of (x, y, z). The weird floating object in the top-right corner of the Scene View is a reminder of how what you're looking at maps to these coordinates.
- The red direction represents X, which is right and left. The red side of the pointer shows which side is right.
- The green direction represents Y, which is up and down. The green side of the pointer shows which side is up.
- The blue direction represents Z, which is forward and back. The blue side of the pointer represents which side is forward.

Use the hand tool to move around the scene by dragging. Hold the Alt key to change the direction you're looking. Use the scroll gesture on your mouse to zoom in and out.

####The Game View
The game view is how your game will look when you hit the Play button. The view in this tab is based on the Main Camera in your scene--when you move the camera, the Game View will be looking at different things. You can't move things around or change the viewing angle from the Game View, only the Scene View.

####Hierarchy
This is a list of all objects in your scene. When you make a new project, Unity puts a camera and a light in the scene for you. The order objects are in doesn't necessarily matter in a 3D game, although if you are using 2D sprites or elements this order will determine what goes on top of what. 2D elements like sprites and menus will render things at the top of the hierarchy first (behind other things), and things at the bottom will render last (in front of other things). Like folders and files, objects in the hierarchy can have child objects, that are considered part of the same object. For example, you could have a Player object with a sprite as a child object, so that the character's graphics are still part of the character but can be controlled separately in space. You can also use an empty GameObject as a container for objects of a similar type, to keep organized--any non-moving scenery or level geometry might be able to go under an "Environment" object just for organization, so you can collapse it and easily see the other things in the Hierarchy if you have a large level with lots of objects.

####Project tab
The Project tab represents the folder that you saved your Unity project to, and shows you all files and folders that are part of that project. If you import audio or pictures into your game, they will be saved here. It's a good idea to make separate folders for each type of file--one for Scripts, one for Audio, one for Animations, one for Images, one for Materials.

####The Inspector
The Inspector tab will be blank until you select an object in the hierarchy. Once you do, it will look like this:

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/inspector.png)

The Inspector gives us all the details about an object. Here, you can see its name, any tags it has, and several things with checkboxes next to them. These are called components. Components are parts you can attach to an object to make it do something. For example, the Directional Light object I selected has a Light component attached. If I uncheck the box, the lighting in my scene will no longer work, and everything will be dark.

Components have text fields, checkboxes, sliders and dropdown lists to let you configure their behavior from the Inspector. For example, look at the Transform component attached to this light. Some of the values for Rotation have been changed, so that the light comes in at an angle. The position is at 0, 3, 0, meaning it is slightly above the center of the game world. The scale is 1, 1, 1, meaning it's the normal size for its type.

There's also a little gear icon at the top right of each component. This will open a menu that lets you copy, paste or remove that component. To add a new component, press the Add Component button at the bottom. You can search by name or by category. If I wanted to add a Lens Flare to my light, I could type "Lens" in the bar or go to Effects -> Lens Flare.

####Creating things

Let's start by creating a cube in our scene. Go to the GameObject menu and select 3D Object, then Cube. You'll see a Cube in your scene view and your hierarchy. You can also right-click in the Hierarchy to bring up the GameObject menu and do it from there.

Let's put an image on our cube. Find an image you like and save it, then go to the Assets menu and select "Import New Asset". You can also right-click in the Project tab and do it from there. Then, select your image and import it. You should see it in your Project tab.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/import-image.png)

To put an image, or _texture_, on a 3D object, we have to make something called a _material_. The material takes the texture and adds extra information about how it will cover the 3D object's surface and how it will be lit. This time, from the Assets menu, go to Create and then go to Material. Click the material and drag it onto the Cube in the Hierarchy.

Select the material you just made in th Project tab, and look at the Inspector. You'll see a little bulls-eye symbol next to something called an "Albedo". Click the bulls-eye and a menu will come up with a list of images you can select. You should see the one you just imported. When you click it, you'll see your Cube is now covered in that image.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/create-material.png)

Let's try another. A script is the code that will tell Unity objects what to do--otherwise, they'll just sit there floating frozen in space when you press play. Open the Assets menu again and this time, select Create -> C# Script. You should see a script show up in your Project tab. Give it a name. When you right-click on the Script file and select "Edit Script", you will see another program called MonoDevelop come up.

###Intro to C-Sharp

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/monodevelop.png)

MonoDevelop is the script editor for Unity. This program is like a text editor, but with some added features that allow you to easily spot spelling and punctuation errors, and a few extra things like built-in testing for the programs you write. Editors like these are called *integrated development environments*, or IDE, and you'll probably see others like it later on. If you choose to work in Unity at home on a Windows computer, for example, you might find Visual Studio, a similar program, more to your liking. Of course, MonoDevelop also runs on Windows too.

If you've opened up a script made in Unity, you'll see a few things are automatically filled in for you. You should see something like this:

```
using UnityEngine;
using System.Collections;

public class MyScript : MonoBehaviour {

  //Use this for initialization
  void Start() {
  }
  
  //Update runs once every frame
  void Update() {
  }
}
```

By the end of today, you'll know what these parts all do to make things happen in your game.

####Why does Unity make this script for me?
Almost every script your game uses needs these things in it in order to work. It saves you the time of having to type it out. For example, the `using UnityEngine` line tells your script about all of the parts of Unity you can use in the script. Without it, it wouldn't know anything about Unity, because C-Sharp is used for a lot of different things besides Unity.

####What if I've never programmed before?
See [this extra lesson](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/CSharpForBeginners.md) if you have never programmed before to go over some basic concepts we'll be using. The rest of this guide will assume you're familiar with variables, operators, functions and conditionals covered there.

####I know JavaScript or Python. What's different about C-Sharp?
If you know JavaScript, you'll find the syntax familiar. There are a few differences in how we write variables and functions, explained below. 

If you know Python, you may already have seen classes and objects. The main difference here is the syntax and how variables are handled. Indentation is important for readability, but to define blocks in C-Sharp we use curly braces {}. It might help to think of Unity classes like Vector3, which hold three floating-point numbers, as tuples.

Variables in C-Sharp must be declared with the data type they will hold. If you want the variable `message` to hold text, you need to declare it as `string message`. If you need a variable for a for-loop, you have to declare it as an `int` (integer) when you create it. Variable types cannot be changed once they are declared! You can never put a number into `message` unless you convert it to a string.

With functions, you must declare the data type the function will return, and also the data type of any parameters it takes. If a function does not return data, its return type is `void` (nothing). So a function that takes a string and returns another string might look like:

```
string WelcomeMessage(string name) {
  return "Hello, " + name;
}
```

If you were to pass this function an integer, it would throw a TypeError, even though the contents of the function would work with it just fine. Because this function was made to expect a String, it won't take anything else.

Also note that in C-Sharp the semicolon at the end of a statement is not optional. You must include one or the script will throw a SyntaxError and refuse to run.

In C-Sharp, you can also create multiple definitions of the same function that take different parameters (different number of parameters or different data types). This is called _overloading_, and it's how you would handle default parameters. Many Unity functions, like Raycast, have four or five different definitions that all take different parameters. MonoDevelop will show suggestions for an existing function's parameters as you type it, which is helpful, but Raycast has too many different definitions for this to work properly so you should look on the Unity docs for the specific one you want.

###Object-oriented programming

C-Sharp is an object-oriented language. While JavaScript and Python can use classes, objects and scope also, C-Sharp was built from the start to do object-oriented programming. Unity uses this to easily build out complex games with many objects in them.

####Classes
You'll notice that the script Unity gave us also includes this:

`public class MyScriptName : MonoBehaviour {`

A _class_ is a blueprint for a particular thing. It contains data and functions related to what that thing needs and does. In C-Sharp, almost everything is a class, including the data types we talked about earlier. The String class contains data about how to store and handle sequences of text, and gives us functions that we can use on any string we want. As long as we have a variable `message` of type String, we can do things like `message.ToUpper()` and the String class will know how to make `message` into ALL CAPS.

A class can also inherit from another class. This means that the class has properties of its own as well as properties of its "parent" that it inherited from. For example, you could make an "Animal" class that has functions to "Eat()" and "Breathe()", and have a "Bird" class inherit from it. The Bird is an Animal, but not all Animals are Birds, and the Bird can have properties like "beak" and functions like "Fly()" that Animals don't have. However, because the Bird is also an Animal, it will still be able to "Eat()" and "Breathe()" because it inherited those things from being an Animal. The Bird will also probably have its own "Eat()" function that overrides the "Eat()" it inherited from being an Animal, because it has its own specialized way (a beak) of doing this.

So, the script we just created _inherits_ from "MonoBehaviour", since it has its own name followed by it's parent's name. Its "first name" is "MyScriptName", and its "last name" is "MonoBehaviour" like its parent. A MonoBehaviour is a class that provides methods like Start() and Update() that Unity knows to run automatically at certain points in the class's lifetime. We can write our own methods inside of Start() and Update() on our own class to make it do specific things at these times.

####Objects

If a class is a blueprint for how a type of object will behave, an _object_ is the thing we build from that class. You can make a class for an Enemy that includes how it will react when it takes damage, but you need to make Enemies from that blueprint to actually interact with them. Then, each enemy you make will have its own unique health bar that goes up or down independently from other enemies of its kind, while sharing common properties with them.

A GameObject is a type of object that Unity uses to represent anything you put in your game. If it exists in the game world at all, even if it's invisible, it is a GameObject. Each GameObject has certain properties (its position in the world, whether it's enabled or disabled) and certain functions (Destroy, SetActive) that you can call from any GameObject you've made. When you call it from an object, it affects that object only--so using `player.SetActive()` from Player 1's script won't affect Player 2 or 3.

Similarly, when you write a script in Unity, you are making a class. When you attach the script to a GameObject as a component, the component is actually an object made from the class you wrote. This is how the parts of a GameObject can communicate--a method called `GetComponent<ClassName>()` will give us an object made from the class `ClassName` that's attached to the same GameObject. You could use this to have a player's Healthbar tell its Movement to slow down once the health reaches a certain low point, and it would know to only act on the Movement object attached to the same player.

####Scope and privacy

Finally, variables and functions inside classes can hide or show themselves from other classes as needed. We use the keywords `public` and `private` to mark who can see which variables.

Public variables:
- Can be seen in the Editor, so you can change them during gameplay or scene editing. Variables like the speed of a player are good to make public, because you can easily test your game and change the player's speed to see what feels right. Variables that take another GameObject in the scene are also good to make public, since you can drag and drop the object into the editor field.
- Can be seen by other scripts, if they have access to an object of this type. If I make the player's `currentHealth` public, then I could have a Game Over script look at that variable and do something when the player's health reaches zero.
- Can be changed by other scripts. This can lead to unexpected behavior, especially if things happen in a different order than you expected them to. Be careful about changing public variables from within a different script.

Public functions:
- Can be called from other scripts, if they have access to an object of this type. An EnemyAttack script might call a TakeDamage() method on a PlayerHealth.
- Can be called by menu buttons when they are clicked. If you have a pause menu, you will probably have a script with a lot of public functions that do different things when the menu items are clicked.

Private variables and functions:
- Can only be accessed from within the same object that they exist in. If no other script will need access to a variable or function, it's a good idea to make it private.

####Understanding error messages and debug tools
Since C-Sharp is a strict language, if you've written something it doesn't like it will fail to run or even fail to let you playtest the game until it is fixed. It's important to understand what the error messages are saying so that you can fix it and get it running.

Here's what an error message might look like:

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day1/Screenshots/error.png)

It tells you the location of the script the error happened in, the line and column it happened at (line 41, column 38), and a description of what went wrong. In this error, I changed a variable that was supposed to be a `float` to a `string`, and the error message is saying "I can't turn a string into a float on my own. Make sure whatever you give me here is a float."

The Console tab will open automatically if error messages happen. It's a good idea to always keep it open. The other thing the Console tab can do is give you information from within your script even when there are no error messages. You can use `Debug.Log(message)` to print whatever `message` is to the console. For example, if you have a car that isn't responding to input, you could use `Debug.Log(Input)` to print out information about what input is being processed, or what your script is doing with it.
