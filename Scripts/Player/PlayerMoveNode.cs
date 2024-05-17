using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.General;
public partial class PlayerMoveNode : PlayerState
{
    public override void PhysicsUpdate(float delta)
    {
        Vector3 velocity = _player.Velocity;

        // Add the gravity.
        if (!_player.IsOnFloor())
            //velocity.Y -= gravity * (float)delta;

            // Handle Jump.
            if (Input.IsActionJustPressed("ui_accept") && _player.IsOnFloor())
                velocity.Y = _player.JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 inputDir = Input.GetVector(GameConstants.Input.MoveLeft, GameConstants.Input.MoveRight, GameConstants.Input.MoveUp, GameConstants.Input.MoveDown);
        Vector3 direction = (_player.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {	
            velocity.X = direction.X * _player.Speed;
            velocity.Z = direction.Z * _player.Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(_player.Velocity.X, 0, _player.Speed);
            velocity.Z = Mathf.MoveToward(_player.Velocity.Z, 0, _player.Speed);
        }

        _player.Velocity = velocity;
        _player.MoveAndSlide();
        _player.PlayerSpriteNode.Play(GameConstants.Animation.AnimMoving);
        _Flip();
        if (velocity == Vector3.Zero)
        {
            _stateMachine.TransitionTo("Idle");
        }
    }

    private void _Flip()
    {
        if(_player.Velocity.X != 0)
            _player.PlayerSpriteNode.FlipH = _player.Velocity.X<0;
    }
}
