using Godot;
using System;

public partial class BurstOfAction : AbilityData
{
	public override void Use(Player player)
	{
		if (CanUse(player)) 
		{
			base.Use(player);

			player.ActionPoints += 2;			
		}
	}
}
