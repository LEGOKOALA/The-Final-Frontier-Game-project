using Godot;
using System;

public partial class Button : Godot.Button
{
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		this.Visible = false;

		ColorRect colorRect = GetParent().GetNode<ColorRect>("ColorRect");
		colorRect.Visible = false;
	}
}
