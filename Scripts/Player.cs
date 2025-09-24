using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 130.0f;
	public const float JumpVelocity = -60.0f;
	public const float Gravity = 60.0f;

	[Signal]
	public delegate void DiedEventHandler();

	public void Die()
	{
		EmitSignal(SignalName.Died);
		QueueFree();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
			Speed = 85.0f;
		}

		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("move");
			if (velocity.X>0){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH=false;
			}
			else if(velocity.X<0){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH=true;
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
