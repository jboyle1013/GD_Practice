using Godot;
namespace GD_Practice.Scripts.Player;

public partial class Player : CharacterBody3D
{
    [Export] public AnimatedSprite3D PlayerSpriteNode;
    
    public float Speed = 5.0f;
    public float JumpVelocity = 4.5f;
	
    

    public StateMachine _stateMachine;
    
    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
    
    
    public override void _Ready()
    {
        _stateMachine = GetNode<StateMachine>("StateMachine");
    }

    public override void _Process(double delta)
    {
        GD.Print(_stateMachine.State.Name);
    }
    
    
}