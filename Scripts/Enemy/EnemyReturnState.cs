using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.Enemy;
using GD_Practice.Scripts.General;
public partial class EnemyReturnState : EnemyState
{
    
    public override void _Ready()
    {
        base._Ready();
        destination = GetPointGlobalPosition(0);
    }

    public override void EnterState()
    {
        _character.SpriteNode.Play(GameConstants.EnemyAnimation.AnimMoving);
        _character.AgentNode.TargetPosition = destination;
    }

    public override void PhysicsUpdate(double delta)
    {
        if (_character.AgentNode.IsNavigationFinished())
        {
            GD.Print("Reached Destination");
            _stateMachine.TransitionTo("Idle");
        }
        Move();
    }


}
