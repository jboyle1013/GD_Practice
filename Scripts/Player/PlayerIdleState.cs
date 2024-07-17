using Godot;
using System;
using GD_Practice.Scripts.General;
using GD_Practice.Scripts.Player;
using Godot.Collections;


public partial class PlayerIdleState : PlayerState
{	
	[Export] protected Timer dashReloadNode;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Idle Ready");
		base._Ready();
		
		
	}

	public override void EnterState()
	{
		// We must declare all the properties we access through `owner` in the `Player.cs` script.
		_character.SpriteNode.Play(GameConstants.Animation.AnimIdle);

	}

	public override void PhysicsUpdate(double delta)
	{
		if (Input.IsActionPressed(GameConstants.Input.MoveLeft) ||
		    Input.IsActionPressed(GameConstants.Input.MoveRight) || Input.IsActionPressed(GameConstants.Input.MoveUp) ||
		    Input.IsActionPressed(GameConstants.Input.MoveDown) || Input.IsActionPressed(GameConstants.Input.Jump))
		{
			_stateMachine.TransitionTo("Move");
		}
		else if (Input.IsActionPressed(GameConstants.Input.Dash) && dashReloadNode.IsStopped())
		{
			_stateMachine.TransitionTo("Dash");
		}
			
	}
}
