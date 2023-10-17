using Godot;
using System;

public partial class TakeDamage : Node
{
	//public static Action playerDead;

	//public GameObject corpse; //Труп или объект после смерти(не путать с лутом)
	//public GameObject[] lootAfterDeath; //Вещи выпадающие из обхекта после смерти

	////Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
	////Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
	////
	////
	////
	////К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона



	//public void TakeDamage
	//    (
	//    int physicalDamage = 0,
	//    int poisonDamage = 0,
	//    int fireDamage = 0,
	//    int frostDamage = 0,
	//    int drunkennessDamage = 0
	//    )
	//{
	//    //GetComponent<MainObject>().HP -= poisonDamage * (1 - GetComponent<MainObject>().poisonResist / 100);
	//    //GetComponent<MainObject>().HP -= fireDamage * (1 - GetComponent<MainObject>().fireResist / 100);
	//    //GetComponent<MainObject>().HP -= frostDamage * (1 - GetComponent<MainObject>().frostResist / 100);
	//    //GetComponent<MainObject>().HP -= drunkennessDamage * (1 - GetComponent<MainObject>().drunkennessResist / 100);


	//    physicalDamage -= GetComponent<MainObject>().physicalResist;

	//    if (physicalDamage > 0)
	//    {
	//        if (GetComponent<MainObject>().armor <= 0)
	//        {
	//            GetComponent<MainObject>().HP -= physicalDamage;
	//        }

	//        GetComponent<MainObject>().armor -= 1;
	//    }



	//    CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f); //Дрожание экрана при получении урона
	//    //GetComponent<MainObject>().anim.SetTrigger("TakeDamage");

	//    if (GetComponent<MainObject>().HP <= 0 && gameObject != null)
	//    {
	//        Die();
	//    }
	//}


	//public void Die()
	//{
	//    Debug.Log($"Я {this.name} умер");

	//    //Спавнит случайны лут из списка с вероятностью 50%
	//    if (Random.Range(0, 100) > 50 && lootAfterDeath != null)
	//    {
	//        try
	//        {
	//            GameObject loot = Instantiate(lootAfterDeath[Random.Range(0, lootAfterDeath.Length)]);
	//            loot.GetComponent<BaseObject>().coordinate = GetComponent<BaseObject>().tileMap.WorldToCell(transform.position);
	//        }
	//        catch
	//        {

	//        }
	//    }



	//    //Instantiate(corpse, transform.position, transform.rotation);

	//    GetComponent<MainObject>().anim.SetTrigger("Die");

	//    //Если умер игрок
	//    if (GetComponent<MainObject>() as Player)
	//    {
	//        playerDead?.Invoke();
	//    }

	//    //Если умер игрок
	//    if (GetComponent<MainObject>() as Enemy)
	//    {
	//        if (GetComponent<Enemy>().typeEnemy == Enemy.TypeEnemy.captain)
	//        {
	//            LevelManager.levelEnded?.Invoke();
	//        }
	//    }

	//    Destroy(this.gameObject);
	//}

	//public void Kill()
	//{
	//    GetComponent<MainObject>().HP = -1000;
	//}//Метод для отладки
}
