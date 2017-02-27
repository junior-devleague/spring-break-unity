#Day 1

###Topics and goals
By the end of this lesson, students should be able to...
- Understand the basics of the Unity editor.
- Understand the basics of writing scripts in C#.

###Intro to the Editor

Finally, if you right-click on a Script file and select "Edit Script", you will see another program called MonoDevelop come up.

###Intro to C-Sharp

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

####Classes
You'll notice that the script Unity gave us also includes this:

`public class MyScriptName : MonoBehaviour {`

A _class_ is a blueprint for a particular thing. It contains data and functions related to what that thing needs and does. In C-Sharp, almost everything is a class, including the data types we talked about earlier. The String class contains data about how to store and handle sequences of text, and gives us functions that we can use on any string we want. As long as we have a variable `message` of type String, we can do things like `message.ToUpper()` and the String class will know how to make `message` into ALL CAPS.

A class can also inherit from another class. This means that the class has properties of its own as well as properties of its "parent" that it inherited from. For example, you could make an "Animal" class that has functions to "Eat()" and "Breathe()", and have a "Bird" class inherit from it. The Bird is an Animal, but not all Animals are Birds, and the Bird can have properties like "beak" and functions like "Fly()" that Animals don't have. However, because the Bird is also an Animal, it will still be able to "Eat()" and "Breathe()" because it inherited those things from being an Animal. The Bird will also probably have its own "Eat()" function that overrides the "Eat()" it inherited from being an Animal, because it has its own specialized way (a beak) of doing this.

So, the script we just created _inherits_ from "MonoBehaviour", since it has its own name followed by it's parent's name. Its "first name" is "MyScriptName", and its "last name" is "MonoBehaviour" like its parent. A MonoBehaviour is a class that provides methods like Start() and Update() that Unity knows to run automatically at certain points in the class's lifetime. We can write our own methods inside of Start() and Update() on our own class to make it do specific things at these times.

####Objects

####Conditionals

####Scope and privacy

####Understanding error messages and debug tools
