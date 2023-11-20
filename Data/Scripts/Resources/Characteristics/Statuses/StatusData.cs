using Godot;
using System;

public partial class StatusData : CharacteristicData
{
    [ExportGroup("Префаб еффекта")]
    //Сцена еффекта(необязательно)
    [Export] public PackedScene scene { get; set; }
}
