# JSONSavingSystem
This is a simple saving system that uses JSON to serialize and deserialize data. It can be used for saving game states and game settings.

## Supported Data Types

* Primitive data types
* Strings
* Enums
* Raw arrays, lists, stacks, queues, hash sets, dictionaries
* Unity types: Vector2, Vector2Int, Vector3, Vector3Int, Quaternion, Color (more Unity types can be serialized and deserialized if you implement custom JSON converters)
* Data-only structs and classes with supported types mentioned above (as long as they are marked with System.Serializable)

## How to Install

* Install the Newtonsoft JSON package (Window &#8594; Package Manager &#8594; Add Package by Name &#8594; com.unity.nuget.newtonsoft-json).
* Copy the SavingSystem folder (Assets/Script/SavingSystem) from this repo to your project.

## How to Use

You can have a look at the example script in Assets/Scripts/Samples to see how the saving system is used.
* Create a SaveData object to store data. To add or update an entry in the SaveData object, use the SetValue() method. To get the value of an entry, use the GetValue() method.
* Create a Serializer object to serialize and deserialize data.
* Use StreamWriter and StreamReader to save/load data to/from a file.

## How to Implement Custom Converters

* Create a new class that derives from PartialConverter.
* Override the ReadValue() and WriteValue() methods.
* After creating a Serializer object, use the AddConverter() to add the custom converter to the object.