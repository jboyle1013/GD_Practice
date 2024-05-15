using Godot;

namespace GD_Practice.Scripts.General;

public class GameConstants
{
    // Animations
    public static class Animation
    {
        public static readonly StringName AnimIdle = new ("idle");
        public static readonly StringName AnimMoving =  new ("running");
        public static readonly StringName AnimSlashing = new ("slashing");
       public static readonly StringName AnimSliding = new ("sliding");
       public static readonly StringName AnimDying = new ("dying");
    }

    public static class Input
    {
        // Inputs
        public static readonly StringName MoveLeft = new("ui_left");
        public static readonly StringName MoveRight = new("ui_right");
        public static readonly StringName MoveUp = new("ui_up");
        public static readonly StringName MoveDown = new("ui_down");
    }

}
