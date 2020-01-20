using Godot;
using System;

public class RayInstance3 : RayCast
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var collider = GetCollider();
        if (collider == null)
        {
            GD.Print("test successful");
        }
        else
        {
            GD.Print("test failed");
        }
        QueueFree();
    }
}
