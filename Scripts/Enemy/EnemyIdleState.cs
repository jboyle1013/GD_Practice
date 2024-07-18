using Godot;
using System;
using GD_Practice.Scripts.Enemy;
using GD_Practice.Scripts.General;
using GD_Practice.Scripts.Player;
using Godot.Collections;


public partial class EnemyIdleState : EnemyState
{	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Idle Ready");
		base._Ready();
		
		
	}

	public override void EnterState()
	{
		// We must declare all the properties we access through `owner` in the `Player.cs` script.
		GD.Print("Idle Enter");
		_character._spriteAnimations.Play(GameConstants.EnemyAnimation.AnimIdle);

	}

	public override void PhysicsUpdate(double delta)
	{
		if (!_character.AgentNode.IsNavigationFinished())
		{
			_stateMachine.TransitionTo("Return");
		}
		
		// else if (Input.IsActionPressed(GameConstants.Input.Dash) && dashReloadNode.IsStopped())
		// {
		// 	_stateMachine.TransitionTo("Dash");
		// }
			
	}
}
