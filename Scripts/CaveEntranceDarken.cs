using Godot;
using System;

public partial class CaveEntranceDarken : Area2D
{
	private ColorRect colorrect;
	private ColorRect colorrect2;
	private ColorRect colorrect3;


	public override void _Ready()
	{
		colorrect = GetNode<ColorRect>("ColorRect");
		colorrect2 = GetNode<ColorRect>("ColorRect2");
		colorrect3 = GetNode<ColorRect>("ColorRect3");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			colorrect.Visible = true;
			colorrect2.Visible = false;
			colorrect3.Visible = false;
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is Player)
		{
			colorrect.Visible = false;
			colorrect2.Visible = true;
			colorrect3.Visible = true;
		}
	}
}
