using Godot;
using System;

public partial class CaveEntranceDarken : Area2D
{
	private ColorRect colorrect;
	private ColorRect colorrect2;
	private ColorRect colorrect3;
	private ColorRect colorrect4;
	private ColorRect colorrect5;


	public override void _Ready()
	{
		colorrect = GetNode<ColorRect>("ColorRect");
		colorrect2 = GetNode<ColorRect>("ColorRect2");
		colorrect3 = GetNode<ColorRect>("ColorRect3");
		colorrect4 = GetNode<ColorRect>("ColorRect4");
		colorrect5 = GetNode<ColorRect>("ColorRect5");
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
			colorrect4.Visible = false;
			colorrect5.Visible = false;
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is Player)
		{
			colorrect.Visible = false;
			colorrect2.Visible = true;
			colorrect3.Visible = true;
			colorrect4.Visible = true;
			colorrect5.Visible = true;

		}
	}
}
