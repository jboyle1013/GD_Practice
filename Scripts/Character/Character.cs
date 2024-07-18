using Godot;
namespace GD_Practice.Scripts.Character;

public partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public Sprite3D SpriteNode { get; private set; }
    [Export] public AnimationPlayer _spriteAnimations { get; private set; }
    // [Export] public AnimatedSprite3D SpriteNode { get; private set; }
    [Export] public StateMachine _stateMachine;
    [Export(PropertyHint.Range, "0,10,0.1")] public float Speed = 5.0f;
    [Export(PropertyHint.Range, "0,10,0.1")] public float JumpVelocity = 4.5f;
    
    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    
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