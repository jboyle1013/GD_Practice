using Godot;
using System;
using GD_Practice.Scripts.General;

public partial class PlayerIdleNode : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player_node characterNode = GetOwner<player_node>();
		characterNode.PlayerSpriteNode.Play(GameConstants.Animation.AnimIdle);
	}
	
}
