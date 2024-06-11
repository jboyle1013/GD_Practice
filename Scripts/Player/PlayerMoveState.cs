using Godot;
using System.Collections.Generic;
using GD_Practice.Scripts.General;

/// <summary>
/// The PlayerMoveState class represents the state of the player when they are moving.
/// </summary>
public partial class PlayerMoveState : CharacterState
{
    [Export] protected Timer dashReloadNode;

    /// <summary>
    /// Updates the physics of the player.
    /// </summary>
    /// <param name="delta">The time elapsed since the last physics frame.</param>
    public override void PhysicsUpdate(double delta)
    {
        Vector3 velocity = _character.Velocity;

        // Add the gravity.
        if (!_character.IsOnFloor())
            velocity.Y -= _character.gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed(GameConstants.Input.Jump))
        {
            _stateMachine.TransitionTo("Jump");
            return; // Exit early to prevent further updates in this frame
        }

        // Get the input direction and handle the movement/deceleration.
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
        _character.SpriteNode.Play(GameConstants.Animation.AnimMoving);
        _Flip();

        if (velocity == Vector3.Zero)
        {
            _stateMachine.TransitionTo("Idle");
        }
        else if (Input.IsActionPressed(GameConstants.Input.Dash) && dashReloadNode.IsStopped())
        {
            _stateMachine.TransitionTo("Dash");
        }
    }
}