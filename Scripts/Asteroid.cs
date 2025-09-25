using Godot;
using System;

public partial class Asteroid : CharacterBody2D
{
	public float Speed = 100f;
	public float RotationSpeed = 0.5f;
	private Vector2 startPos;
	
	

	public override void _Ready()
	{
		startPos = Position;
	}

	public async override void _PhysicsProcess(double delta)
	{

		Velocity = new Vector2(1, 1).Normalized() * Speed;
		KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			GetNode<AnimatedSprite2D>("explosion").Visible = true;
			await ToSignal(GetTree().CreateTimer(.5f), SceneTreeTimer.SignalName.Timeout);
			if (collision.GetCollider() is Player player)
				player.Die();
			Position = startPos;
			GetNode<AnimatedSprite2D>("explosion").Visible = false;
		}
		Rotation += RotationSpeed * (float)delta;
	}
}
