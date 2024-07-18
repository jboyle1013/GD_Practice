using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.Enemy;
using GD_Practice.Scripts.General;
public partial class EnemyPatrolState : EnemyState
{
    private int pointIndex = 0;
    public override void EnterState()
    {
        _character._spriteAnimations.Play(GameConstants.EnemyAnimation.AnimMoving);
        pointIndex = 1;
        destination = GetPointGlobalPosition(pointIndex);
        _character.AgentNode.TargetPosition = destination;
        _character.AgentNode.NavigationFinished += HandleNavigationFinished;
    }

    public override void PhysicsUpdate(double delta)
    {

        Move(delta);
    }
    
    private void HandleNavigationFinished()
    {
        pointIndex = Mathf.Wrap(
            pointIndex + 1, 0, _character.PathNode.Curve.PointCount
        );

        destination = GetPointGlobalPosition(pointIndex);
        _character.AgentNode.TargetPosition = destination;
    }



}
