using Godot;
using System;

public partial class StartScreen : Node2D
{
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
		GetNode<Button>("Button").ProcessMode = ProcessModeEnum.Always;

		GetTree().Paused = true;
		GetNode<Button>("Button").Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GetTree().Paused = false;
		QueueFree();
	}
}
