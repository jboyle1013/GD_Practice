using Godot;
using GD_Practice.Scripts.General;

public partial class player_node : CharacterBody3D
{
	[Export] public AnimatedSprite3D PlayerSpriteNode;
    
	
	public  float Speed = 5.0f;
	public  float JumpVelocity = 4.5f;
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			//velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector(GameConstants.Input.MoveLeft, GameConstants.Input.MoveRight, GameConstants.Input.MoveUp, GameConstants.Input.MoveDown);
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{	
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		// PlayerSpriteNode.Play(velocity == Vector3.Zero ? GameConstants.Animation.AnimIdle : GameConstants.Animation.AnimMoving);
		_Flip();
	}

	private void _Flip()
	{
		if(Velocity.X != 0)
			PlayerSpriteNode.FlipH = Velocity.X<0;
	}
}
