using Godot;
using System;
using System.Collections.Generic;

public partial class CharacterStorage : Node
{
	// Список всех персонажей
	public static List<Character> characters = new List<Character>();

    public override void _Ready()
    {
        Events.playerDied += ClearAllCharacters;
        Events.levelEnded += ClearAllCharacters;
    }

    private void ClearAllCharacters()
    {
        characters.Clear();
    }
}
