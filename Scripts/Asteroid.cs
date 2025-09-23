using Godot;
using System;
using System.Collections.Generic;

public partial class Asteroid : CharacterBody2D
{
	private float rotation_random = 5.0f;
	private float speed = 1000.0f;
	private float player_x = 1.0f;
	private float player_y = 1.0f;

	public override void _PhysicsProcess(double delta)
	{
		RotationDegrees += (float)rotation_random;
		Vector2 velocity = Velocity;
		velocity.X = (float)(player_x * speed * delta);
		velocity.Y = (float)(player_y * speed * delta);
		Velocity = velocity;
		MoveAndSlide();
	}
}
