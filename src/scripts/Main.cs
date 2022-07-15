using Godot;
using System;

public class Main : Node
{
    private Timer countdown;

    private Player player;

    public override void _Ready()
    {
        GD.Print("START");
        GD.Randomize();        

        player = GetNode<Player>("Player");

        countdown = GetNode<Timer>("Countdown");
        countdown.WaitTime = 10.0f;
        countdown.Start();
    }

    public void onCountdownTimeout()
    {
        GD.Print("DONE");
        player.isTimerRunning = false;
    }
}
