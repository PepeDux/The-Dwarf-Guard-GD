using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;

public partial class InflictWounds : AbilityData
{
	public override async void Use(Player player)
	{
		if (CanUse(player))
		{
			base.Use(player);

			await Task.Run(() => WaitClick(player, checkEnemyCell: true));

			await Task.Delay(50);

			//Events.characterMoved?.Invoke(player);
		}
	}

	protected override void ActionClick(Player player, Vector2I mouseCellPosition)
	{
		base.ActionClick(player, mouseCellPosition);
	}
}
