using Godot;
using GD_Practice.Scripts.General;

public abstract partial class PlayerState : Node
{
    protected player_node characterNode;

    public override void _Ready()
    {
        characterNode = GetOwner<player_node>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == GameConstants.Notifications.NOTIFICATION_ENTER_STATE)
        {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == GameConstants.Notifications.NOTIFICATION_EXIT_STATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() { }
}