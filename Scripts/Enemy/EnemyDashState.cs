using Godot;
using System;
using GD_Practice.Scripts.General;
using GD_Practice.Scripts.Player;
using Godot.Collections;

public partial class EnemyDashState : CharacterState
{
    [Export] protected Timer dashTImerNode;

    [Export] protected Timer dashReloadNode;
    
    [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 10;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Dash Ready");
        dashTImerNode.Timeout += HandleDashTimeout;
        base._Ready();
	
		
    }
    public override void EnterState()
    {
        // We must declare all the properties we access through `owner` in the `Player.cs` script.
        GD.Print("Dash Enter");
        _character = GetOwner<Enemy>();
        Vector2 inputDir = Input.GetVector(GameConstants.Input.MoveLeft, GameConstants.Input.MoveRight, GameConstants.Input.MoveUp, GameConstants.Input.MoveDown);
        Vector3 direction = (_character.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        
        _character.Velocity = new(
            direction.X, 0, direction.Z
        );

        if (_character.Velocity == Vector3.Zero)
        {
            _character.Velocity = _character.SpriteNode.FlipH ?
                Vector3.Left :
                Vector3.Right;
        }

        _character.Velocity *= speed;
        _character.SpriteNode.Play(GameConstants.Animation.AnimSliding);
        dashTImerNode.Start();


    }

    public override void PhysicsUpdate(double delta)
    {
        _character = GetOwner<Enemy>();
        _character.MoveAndSlide();
        _Flip();

    }

    private void HandleDashTimeout()
    {
        _character.Velocity = Vector3.Zero;
        _stateMachine.TransitionTo("Idle");
        dashReloadNode.Start();
    }


}
