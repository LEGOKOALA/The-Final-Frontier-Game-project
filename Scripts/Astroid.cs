using Godot;
using System;
using System.Collections.Generic;

public partial class asteroid; Asteroid
public override void _PhysicsProcess(double delta)
{
	Vector2 velocity = Velocity;
	velocity.X = (float)(player_x * speed * delta);
	velocity.Y = (float)(player_y * speed * delta);
	Velocity = velocity;
	MoveAndSlide;
	
}
