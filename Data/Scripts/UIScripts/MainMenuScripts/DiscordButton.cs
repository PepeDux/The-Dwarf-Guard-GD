using Godot;
using System;
using System.Diagnostics;

public partial class DiscordButton : BaseButton
{
    public override void Pressed()
    {
        base.Pressed();

        Process.Start(new ProcessStartInfo(@"https://discord.gg/WteRfDDE") { UseShellExecute = true });
    }
}
