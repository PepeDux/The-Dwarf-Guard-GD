using Godot;
using System;

public partial class TurnSpeedHScrollBar : BaseHScrollBar
{
    ConfigFile config = new ConfigFile();

    public override void _Ready()
    {
        config.Load("user://Settings.cfg");

        this.Value = (int)config.GetValue("TurnSpeed", "TurnSpeed");

        base._Ready();
    }
    public override void Scrolling()
    {
        base.Scrolling();

        config.Load("user://Settings.cfg");
        // Store some values.
        config.SetValue("TurnSpeed", "TurnSpeed", this.Value);
        // Save it to a file (overwrite if already exists).
        config.Save("user://Settings.cfg");
    }
}