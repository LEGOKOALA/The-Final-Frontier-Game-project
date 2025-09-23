using Godot;
using System;

 public partial class MovingBackground : ParallaxBackground
	{
		[Export] public float ScrollSpeed = 100.0f; 

		public override void _Process(double delta)
		{
			ScrollOffset += new Vector2(ScrollSpeed * (float)delta, 0);

		}
	}
