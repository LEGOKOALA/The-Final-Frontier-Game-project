using Godot;
using System;

public partial class KillZone : Area2D 
{
	// The signal automatically connects to this method.
	private void OnBodyEntered(Node body)
	{
		// Check if the colliding body is the player.
		// The `is` keyword is a clean way to check the type and cast it.
		if (body is Player player)
		{
			// Call the player's death method.
			// You will need to implement a "Die()" method in your Player.cs script.
			player.Die();
			GD.Print("Player entered kill zone!");
		}
	}
}
