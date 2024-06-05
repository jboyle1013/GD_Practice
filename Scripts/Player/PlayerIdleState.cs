using Godot;
using System;
using GD_Practice.Scripts.General;

public partial class PlayerIdleState : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	private player_node characterNode;
	public override void _Ready()
	{
		player_node characterNode = GetOwner<player_node>();
		characterNode.PlayerSpriteNode.Play(GameConstants.Animation.AnimIdle);

		
	}
	public override void _PhysicsProcess(double delta)
	{
		if (characterNode.direction != Vector3.Zero)
		{
			characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
		}
	}

	protected override void EnterState()
	{
		base.EnterState();

		characterNode.PlayerSpriteNode.Play(GameConstants.Animation.AnimIdle);
	}

}

