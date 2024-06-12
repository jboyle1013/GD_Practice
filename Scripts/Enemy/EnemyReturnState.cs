using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.General;
public partial class EnemyReturnState : CharacterState
{

    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPos = _character.PathNode.Curve
            .GetPointPosition(0);
        Vector3 globalPos = _character.PathNode.GlobalPosition;
        destination = localPos + globalPos;
    }

    public override void EnterState()
    {
        _character.SpriteNode.Play(GameConstants.EnemyAnimation.AnimMoving);
        _character.GlobalPosition = destination;
        
    }



}
