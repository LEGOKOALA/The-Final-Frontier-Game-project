using Godot;
using System;

 public partial class MovingBackground : ParallaxBackground
	{
		[Export] public float ScrollSpeed = 100.0f; // Adjust this value in the Inspector

		public override void _Process(double delta)
		{
			// Move the background horizontally
			ScrollOffset += new Vector2(ScrollSpeed * (float)delta, 0);

			// If using a Camera2D, Godot can automatically handle scroll_offset,
			// but for constant movement without camera influence, manual update is needed.
		}
	}
