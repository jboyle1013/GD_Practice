using Godot;
using System;
using GD_Practice.Scripts.General;
using GD_Practice.Scripts.Player;
using Godot.Collections;


public partial class PlayerIdleNode : PlayerState
{	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Idle Ready");
		
		
	}

	public void Enter(Dictionary<string, bool> message = null)
	{
		// We must declare all the properties we access through `owner` in the `Player.cs` script.
		GD.Print("Idle Enter");

	}

	public override void PhysicsUpdate(float delta)
	{
		if (Input.IsActionPressed(GameConstants.Input.MoveLeft) ||
		    Input.IsActionPressed(GameConstants.Input.MoveRight) || Input.IsActionPressed(GameConstants.Input.MoveUp) ||
		    Input.IsActionPressed(GameConstants.Input.MoveDown))
		{
			_stateMachine.TransitionTo("Move");
		}
		else
		{
			Player characterNode = GetOwner<Player>();
			characterNode.PlayerSpriteNode.Play(GameConstants.Animation.AnimIdle);
		}
			
	}
}
