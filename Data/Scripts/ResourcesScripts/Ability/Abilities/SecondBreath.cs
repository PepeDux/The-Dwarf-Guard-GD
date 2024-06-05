using Godot;
using System;
using System.Threading.Tasks;

public partial class SecondBreath : AbilityData
{
	public override async void Use(Player player)
	{
		if (CanUse(player))
		{
			base.Use(player);

			await Task.Run(() => WaitClick(player, checkFreeCell: true));

			await Task.Delay(50);
			
			Events.characterMoved?.Invoke(player);
		}
	}

	protected override void ActionClick(Player player, Vector2I mouseCellPosition)
	{
		base.ActionClick(player, mouseCellPosition);

		player.coordinate = mouseCellPosition;
	}
}
