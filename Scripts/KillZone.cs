using Godot;
using System;

public partial class KillZone : Area2D 
{
	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			((Player)body).Die();
			GD.Print("Player entered kill zone!");
			
			var currentScene = GetTree().CurrentScene;
		
			GetTree().ReloadCurrentScene();

			GD.Print("Player died and scene reset.");
		}
	}
}
