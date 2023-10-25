using Godot;
using System;

public partial class TakeDamage : Node
{
    public static Action playerDead;

    private Character target;

    //public GameObject corpse; //Труп или объект после смерти(не путать с лутом)
    //public GameObject[] lootAfterDeath; //Вещи выпадающие из обхекта после смерти



    //Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
    //Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
    //
    //
    //
    //К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона


    public override void _Ready()
    {
        target = GetParent<Character>();
    }

    public void Take
        (
        int physicalDamage = 0,
        int poisonDamage = 0,
        int fireDamage = 0,
        int frostDamage = 0,
        int drunkennessDamage = 0
        )
    {
        Random random = new Random();

        if (GetParent<Character>().dodge <= random.Next(0, 100))
        {
            int totalDamage = 0;

            //target.HP -= poisonDamage * (1 - target.poisonResist / 100);
            //target.HP -= fireDamage * (1 - target.fireResist / 100);
            //target.HP -= frostDamage * (1 - target.frostResist / 100);
            //target.HP -= drunkennessDamage * (1 - target.drunkennessResist / 100);

            totalDamage += physicalDamage - target.physicalResist;

            if (totalDamage > 0)
            {
                if (target.armor <= 0)
                {
                    target.HP -= totalDamage;
                }

                if(target.armor > 0) 
                {
                    target.armor -= 1;
                }
            }

            //Дрожание экрана при получении урона
            GetTree().Root.GetNode("GameScene").GetNode<CameraShake>("CameraShake").ShakeAsync(1, 1, 15, 10); 

            if (target.HP <= 0)
            {
                Die();
            }
            else
            {
                //Вызов анимации получения урона
                GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("Hurt");
            }
        }
        else
        {
            GD.Print($"Объект '{GetParent().Name}' уклонился");
        }
       
    }


    public void Die()
    {
        GD.Print($"Я {GetParent().Name} умер");

        //Спавнит случайны лут из списка с вероятностью 50%
        //if (Random.Range(0, 100) > 50 && lootAfterDeath != null)
        //{
        //	try
        //	{
        //		GameObject loot = Instantiate(lootAfterDeath[Random.Range(0, lootAfterDeath.Length)]);
        //		loot.GetComponent<BaseObject>().coordinate = GetComponent<BaseObject>().tileMap.WorldToCell(transform.position);
        //	}
        //	catch
        //	{

        //	}
        //}



        //Instantiate(corpse, transform.position, transform.rotation);

        //GetComponent<MainObject>().anim.SetTrigger("Die");

        //if (GetComponent<MainObject>() as Player)
        //{
        //	playerDead?.Invoke();
        //}

        //if (GetComponent<MainObject>() as Enemy)
        //{
        //	if (GetComponent<Enemy>().typeEnemy == Enemy.TypeEnemy.captain)
        //	{
        //		LevelManager.levelEnded?.Invoke();
        //	}
        //}

        GetParent().QueueFree();
    }

    public void Kill()
    {
        target.HP = -1000;
    }//Метод для отладки
}
