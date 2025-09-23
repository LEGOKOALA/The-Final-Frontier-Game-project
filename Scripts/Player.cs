using Godot;
using System;

public partial class GameState : Node
{
	public static bool GameStarted = false;
}

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -200.0f;
	public int Health = 100;

	[Signal]
	public delegate void DiedEventHandler();

	public void Die()
	{
		EmitSignal(SignalName.Died);
		QueueFree();
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Die();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (!GameState.GameStarted)
			return;

		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
