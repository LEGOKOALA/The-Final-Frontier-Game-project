using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -200.0f;

	[Signal]
	public delegate void DiedEventHandler();

	public void Die()
	{
		// Emit a signal for other parts of the game (like a UI) to know the player died.
		EmitSignal(SignalName.Died);

		// For this example, we simply hide the player and disable collision.
		// More advanced games might use a respawn system, an animation, or destroy the node.
		QueueFree(); // Deletes the player node from the scene tree.

		// OR:
		// SetProcessMode(ProcessModeEnum.Disabled); // Stops processing for the player.
		// Hide(); // Hides the player mesh or sprite.
		// GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
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
