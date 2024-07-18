using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.Enemy;
using GD_Practice.Scripts.General;
public partial class EnemyReturnState : EnemyState
{
    private int pointIndex = 0;
    
    public override void _Ready()
    {
        base._Ready();
        destination = GetPointGlobalPosition(0);
    }

    public override void EnterState()
    {
        _character._spriteAnimations.Play(GameConstants.EnemyAnimation.AnimMoving);
        _character.AgentNode.TargetPosition = destination;
    }

    public override void PhysicsUpdate(double delta)
    {
        if (_character.AgentNode.IsNavigationFinished())
        {
            GD.Print("Reached Destination");
            _stateMachine.TransitionTo("Patrol");
        }
        Move(delta);
    }


}
