using Godot;
using System;

public partial class AbilityData : Resource
{
	[Export] public Texture2D abilityImage { get; set; }

	[ExportGroup("Стоимсоть применения абилки")]
	[Export] public int actionPointsCost { get; set; }
	[Export] public int movePointsCost { get; set; }
	[Export] public int beerPointsCost { get; set; }

	public virtual void Use(Character user)
	{
		GD.Print("ABILITY USED");
	}

	protected bool CanUse(Character user)
	{
		if (user.BeerPoints >= beerPointsCost && user.ActionPoints >= actionPointsCost && user.MovePoints >= movePointsCost)
		{
			return true;
		}

		return false;
	}
}
