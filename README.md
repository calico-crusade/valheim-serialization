# CardboardBox.Valheim
This library allows for Reading and Writing of Valheim save files.

## Features
* Supported Files:
    * World Metadata (FWL) - This gives metadata about the different worlds (Seed, Name, etc)
    * Character Save File (FCH) - This is the profile of a specific character
* Not Supported Files:
    * World Saves (DB) - This is the save point of all world data (Support coming soon (TM))
* POCO classes: The models used for data storage don't have anything other than data in them (So you can serialize to JSON and such)
* Extendable Serialization System: You can polyfill any models that I don't have covered pretty easily
    * [Here](https://github.com/calico-crusade/valheim-serialization/blob/main/CardboardBox.Valheim.Serialization/CardboardBox.Valheim.Serialization/Models/World.cs) is an example of a POCO model
    * [Here](https://github.com/calico-crusade/valheim-serialization/blob/main/CardboardBox.Valheim.Serialization/CardboardBox.Valheim.Serialization/WorldSerializer.cs) is the serializer for that POCO model

## Usage
Install the library via [NUGET](https://www.nuget.org/packages/CardboardBox.Valheim.Serialization/)
```
> Install-Package CardboardBox.Serialization.Valheim
```

Start reading and writing files:
```CSharp
using CardboardBox.Serialization.Valheim;

namespace TestApp
{
    public class Program 
    {
        public static void Main()
        {
            var world = Serializer.Worlds.Read("worldname.fwl");
            Serializer.Worlds.Write("worldname2.fwl", world);

            var character = Serializer.Characters.Read("character.fch");
            Serializer.Characters.Write("character2.fwl", character);
        }
    }
}
```

You can also read and write using streams:
```CSharp 
using CardboardBox.Serialization.Valheim;
using System.IO;

namespace TestApp
{
    public class Program 
    {
        public static void Main()
        {
            using (var worldFile = File.OpenRead("worldname.fwl"))
            using (var worldOutputFile = File.Create("worldname2.fwl"))
            {
                var world = Serializer.Worlds.Read(worldFile);
                Serializer.Worlds.Write(worldOutputFile, world);
            }

            using (var characterFile = File.OpenRead("character.fch"))
            using (var characterOutputFile = File.Create("character2.fch"))
            {
                var character = Serializer.Characters.Read(characterFile);
                Serializer.Characters.Write(characterOutputFile, character);
            }
        }
    }
}
```
