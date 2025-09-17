using Godot;
using System;

public partial class Platform : AnimatableBody2D
{
	
	public void FlipSprite() {
		var sprite = GetChild<Sprite2D>(0);
		var exhaust = GetChild<AnimatedSprite2D>(2);
		sprite.FlipH = !sprite.FlipH;
		exhaust.FlipH = !exhaust.FlipH;
		exhaust.Position *= new Vector2(-1, 1);
	}
}
