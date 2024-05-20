using Godot;
using System;

public partial class BurstOfAction : AbilityData
{


	public override void Use(Character user)
	{
		GD.Print(user.BeerPoints + " " + beerPointsCost + " " + user.ActionPoints + " " + actionPointsCost + " " + movePointsCost + " " + user.MovePoints);

		if (user.BeerPoints >= beerPointsCost && user.ActionPoints >= actionPointsCost && user.MovePoints >= movePointsCost) 
		{
			user.BeerPoints -= beerPointsCost;
			user.ActionPoints -= actionPointsCost;
			user.MovePoints -= movePointsCost;

			user.ActionPoints += 2;			
		}
	}
}
