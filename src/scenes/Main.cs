using Godot;
using System;

public class Main : Node
{
    public override void _Ready()
    {
        GD.Print("START");
        GD.Randomize();        
    }

    public void onCountdownTimeout()
    {
        GD.Print("DONE");
    }
}
