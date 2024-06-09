using Godot;
using System;

public partial class CharacterAbilitiesStorage : Node
{
    [ExportGroup("Абилки")]
    [Export] public AbilityData[] abilities;
}
