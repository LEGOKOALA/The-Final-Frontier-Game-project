using Godot;
using System;


public partial class CaveEntranceDarken : Area2D
{
	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			GetNode<ColorRect>("ColorRect").Visible = true;
		}
	}





	private void OnBodyExited(Node2D body)
	{
		if (body is Player)
		{
			GetNode<ColorRect>("ColorRect").Visible = false;
		}
	}
}
