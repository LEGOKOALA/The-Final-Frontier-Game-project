using Godot;
using System;

public partial class KillZone : Area2D
{
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			player.Die();
			var scenePath = GetTree().CurrentScene.SceneFilePath;
			GetTree().ChangeSceneToFile(scenePath);
		}
	}
}
