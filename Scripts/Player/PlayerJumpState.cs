using Godot;
using GD_Practice.Scripts.General;
using GD_Practice.Scripts.Player;

/// <summary>
/// Represents the state of a player when jumping.
/// </summary>
public partial class PlayerJumpState : PlayerState
{
    /// <summary>
    /// Indicates whether the player has performed a double jump.
    /// </summary>
    private bool double_jump = false;
    
    /// <summary>
    /// Method to enter the PlayerJumpState.
    /// </summary>
    public override void EnterState()
    {
        Vector3 velocity = _character.Velocity;
        if (_character.IsOnFloor() || !double_jump)
        {
            velocity.Y = _character.JumpVelocity;
            if (!double_jump && !_character.IsOnFloor())
            {
                double_jump = true;
            }
            _character.Velocity = velocity;
        }
    }

    /// <summary>
    /// Update the physics of the player during the jump state.
    /// </summary>
    /// <param name="delta">The time elapsed since the last frame.</param>
    public override void PhysicsUpdate(double delta)
    {
        Vector3 velocity = _character.Velocity;

        // Add gravity
        if (!_character.IsOnFloor())
        {
            velocity.Y -= _character.gravity * (float)delta;
        }
        else
        {
            double_jump = false;
            _stateMachine.TransitionTo("Move");
        }

        // Handle horizontal movement during jump
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
    }
}
