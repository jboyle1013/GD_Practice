namespace GD_Practice.Scripts.Enemy;
using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.Enemy;
using GD_Practice.Scripts.General;
public partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected Vector3 GetPointGlobalPosition(int index)
    {
        Vector3 localPos = _character.PathNode.Curve
            .GetPointPosition(index);
        Vector3 globalPos = _character.PathNode.GlobalPosition;
        return localPos + globalPos;
    }

    protected void Move()
    {
        _character.Velocity = _character.GlobalPosition
            .DirectionTo(destination);

        _character.MoveAndSlide();
    }

}