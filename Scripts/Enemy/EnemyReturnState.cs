using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.General;
public partial class EnemyReturnState : CharacterState
{

    public override void PhysicsUpdate(double delta)
    {
        Vector3 velocity = _character.Velocity;

        // Add the gravity.
        if (!_character.IsOnFloor())
            velocity.Y -= _character.gravity * (float)delta;

            // Handle Jump.
            if (Input.IsActionJustPressed(GameConstants.Input.Jump) && _character.IsOnFloor())
                velocity.Y = _character.JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actidons with custom gameplay actions.
        Vector2 inputDir = Input.GetVector(GameConstants.Input.MoveLeft, GameConstants.Input.MoveRight, GameConstants.Input.MoveUp, GameConstants.Input.MoveDown);
        Vector3 direction = (_character.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {	
            velocity.X = direction.X * _character.Speed;
            velocity.Z = direction.Z * _character.Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(_character.Velocity.X, 0, _character.Speed);
            velocity.Z = Mathf.MoveToward(_character.Velocity.Z, 0, _character.Speed);
        }

        _character.Velocity = velocity;
        _character.MoveAndSlide();
        _character.SpriteNode.Play(GameConstants.EnemyAnimation.AnimMoving);
        // _Rotate((float)delta);
        _Flip();
        if (velocity == Vector3.Zero)
        {
            _stateMachine.TransitionTo("Idle");
        }
        // else if (Input.IsActionPressed(GameConstants.Input.Dash) && dashReloadNode.IsStopped())
        // {
        //     _stateMachine.TransitionTo("Dash");
        // }

    }


}
