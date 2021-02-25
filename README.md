# SharpBukkit

SharpBukkit is a server software for Minecraft b1.7.3 translated to C# from the original minecraft_server.jar

# Status

SharpBukkit is currently **unstable**:

* Minor in-game testing has been performed with only one player
* Various transient exceptions under computational stress

# Features
* Reflection-based command system
    * Extending `SharpBukkitCommandController` and decorating methods with `SharpBukkitCommand` is all that's necessary for a command to be recognized
    * See `SharpBukkitLive/SharpBukkit/BasicCommands.cs` for example usage