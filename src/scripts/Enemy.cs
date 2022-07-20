using Godot;
using System;

public class Enemy : AnimatedSprite
{

  public void resetPosition()
  {
    this.Animation = "Standing";
    this.FlipH = true;
  }

  public void attack()
  {
    this.Animation = "Attacking";
    this.FlipH = false;
  }

  public void faint()
  {
    this.Animation = "Fainting";
    this.FlipH = false;
  }
  
}
