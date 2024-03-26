# JSONSavingSystem
This is a simple saving system that uses JSON to serialize and deserialize data. It can be used for saving game states and game settings.

## How to Install

* Install the Newtonsoft Json package (Window->Package Manager->Add Package by Name->com.unity.nuget.newtonsoft-json).
* Copy the SavingSystem folder (Assets/Script/SavingSystem) from this repo to your project.

## How to Use

You can have a look at the example script in Assets/Scripts/Samples to see how the saving system is used.
* Create a SaveData object to store data. To add or update an entry in the SaveData object, use the SetValue() method. To get the value of an entry, use the GetValue() method.
* Create a Serializer object to serialize and deserialize data.
* Use StreamWriter and StreamReader to save/load data to/from a file.