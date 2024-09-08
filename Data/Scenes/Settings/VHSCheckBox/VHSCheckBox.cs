using Godot;
using System;

public partial class VHSCheckBox : BaseCheckBox
{
    ConfigFile config = new ConfigFile();

    public override void _Ready()
	{
        config.Load("user://Settings.cfg");

        ButtonPressed = (bool)config.GetValue("VHS", "VHS");
    }

    public override void Pressed()
    {
        base.Pressed();

        config.Load("user://Settings.cfg");

        if (ButtonPressed == true)
		{
            // Store some values.
            config.SetValue("VHS", "VHS", true);       

            // Save it to a file (overwrite if already exists).
            config.Save("user://Settings.cfg");
        }
        else if (ButtonPressed == false)
        {
            // Store some values.
            config.SetValue("VHS", "VHS", false);

            // Save it to a file (overwrite if already exists).
            config.Save("user://Settings.cfg");
        }
    }
}
