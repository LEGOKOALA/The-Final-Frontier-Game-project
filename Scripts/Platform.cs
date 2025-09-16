using Godot;
using System;

public partial class Platform : AnimatableBody2D
{
	sprite=Node.GetChild ("Sprite2D")
	sprite.FlipH = True
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{ 
	}
}
