using Godot;

namespace GD_Practice.Scripts.General;

public class GameConstants
{
    // Animations
    public static class Animation
    {
        public static readonly StringName AnimIdle = new ("TestPlayer/Idle");
        public static readonly StringName AnimMoving =  new ("TestPlayer/Run");
        public static readonly StringName AnimSlashing = new ("TestPlayer/Slash");
       public static readonly StringName AnimSliding = new ("TestPlayer/Slide");
       public static readonly StringName AnimDying = new ("TestPlayer/Die");
    }

    public static class Input
    {
        // Inputs
        public static readonly StringName MoveLeft = new("player_left");
        public static readonly StringName MoveRight = new("player_right");
        public static readonly StringName MoveUp = new("player_up");
        public static readonly StringName MoveDown = new("player_down");
        public static readonly StringName Dash = new("player_dash");
        public static readonly StringName Jump = new("player_jump");
    }
    
    public static class EnemyAnimation
    {
        public static readonly StringName AnimIdle = new ("EnemyTest/Idle");
        public static readonly StringName AnimMoving =  new ("EnemyTest/Move");
        public static readonly StringName AnimSlashing = new ("EnemyTest/Attack");
        public static readonly StringName AnimHurt = new ("EnemyTest/Hit");
        public static readonly StringName AnimDying = new ("EnemyTest/Death");
    }

}
