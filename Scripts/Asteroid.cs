using Godot;
using System;

public partial class Asteroid : CharacterBody2D
{
	public Vector2 Velocity = new Vector2(60, 60);
	public float RotationSpeed = 2f;
	private Vector2 _spawnPosition;

	public override void _Ready()
	{
		_spawnPosition = GlobalPosition;
	}

	public override void _PhysicsProcess(double delta)
	{
		KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
		Rotation += RotationSpeed * (float)delta;

		if (collision != null)
		{
			GlobalPosition = _spawnPosition;
			Visible = true;
		}
	}
}
