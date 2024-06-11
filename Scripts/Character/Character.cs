using Godot;
namespace GD_Practice.Scripts.Character;

public partial class Character : CharacterBody3D
{
    [Export] public AnimatedSprite3D SpriteNode { get; private set; }
    [Export] public StateMachine _stateMachine;
    [Export(PropertyHint.Range, "0,10,0.1")] public float Speed = 5.0f;
    [Export(PropertyHint.Range, "0,10,0.1")] public float JumpVelocity = 4.5f;
    
    
    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
    
    
    public override void _Ready()
    {
        _stateMachine = GetNode<StateMachine>("StateMachine");
    }

    public override void _Process(double delta)
    {
    }
}