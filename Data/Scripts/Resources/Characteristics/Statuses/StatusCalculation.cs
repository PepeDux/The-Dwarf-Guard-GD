using Godot;
using System;
using System.Collections.Generic;

public partial class StatusCalculation : Node
{
    public List<StatusData> activeStatuses = new List<StatusData>();


    public override void _Ready()
	{
        foreach (StatusData status in activeStatuses)
        {
            Сalculation(status, 1);
        }
    }


    public void AddStatus(StatusData status)
    {
        if (status != null)
        {
            if (!activeStatuses.Contains(status))
            {
                Сalculation(status, 1);
                activeStatuses.Add(status);
            }
        }

    }

    public void RemoveStatus(StatusData status)
    {
        if (status != null)
        {
            if (activeStatuses.Contains(status))
            {
                Сalculation(status, -1);
                activeStatuses.Remove(status);
            }
        }
    }



    public void Сalculation(StatusData status, int mod)
    {
        GetParent<Character>().strength += mod * status.strength;
        GetParent<Character>().dexterity += mod * status.agility;
        GetParent<Character>().inteligence += mod * status.intel;
        GetParent<Character>().constitution += mod * status.constitution;
        GetParent<Character>().wisdom += mod * status.wisdom;

        GetParent<Character>().criticalDamage += mod * status.criticalDamage;
        GetParent<Character>().criticalDamageChance += mod * status.criticalDamageChance;
        GetParent<Character>().precision += mod * status.precision;
        GetParent<Character>().drunkenness += mod * status.drunkenness;

        GetParent<Character>().poisonResist += mod * status.poisonResist;
        GetParent<Character>().fireResist += mod * status.fireResist;
        GetParent<Character>().frostResist += mod * status.frostResist;
        GetParent<Character>().drunkennessResist += mod * status.drunkennessResist;
    }
}
