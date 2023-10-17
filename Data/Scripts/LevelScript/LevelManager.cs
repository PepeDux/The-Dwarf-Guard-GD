using Godot;
using System;

public partial class LevelManager : Node
{
	private PlayerSpawner playerSpawner;
	private EnemySpawner enemySpawner;
	private StaticObjectSpawner staticObjectSpawner;
	private FunctionalObjectSpawner functionalObjectSpawner;

	public static int currentLevel = 1;

	//private void OnEnable()
	//{
	//    CardMaker.endSelectCard += LevelGenerate;
	//}
	//private void OnDisable()
	//{
	//    CardMaker.endSelectCard -= LevelGenerate;
	//}
	public override void _Ready()
	{
		enemySpawner = GetTree().Root.GetNode("GameScene").GetNode<EnemySpawner>("Enemies");
		//staticObjectSpawner = GetTree().Root.GetNode("GameScene").GetNode<StaticObjectSpawner>("StaticObjects");
		//functionalObjectSpawner = GetTree().Root.GetNode("GameScene").GetNode<FunctionalObjectSpawner>("FunctionalObjects");
		//playerSpawner = GetTree().Root.GetNode("GameScene").GetNode<PlayerSpawner>("PlayerHolder");
		LevelGenerate();
	}

	public void LevelGenerate()
	{
		enemySpawner.SpawnEnemy();
		//staticObjectSpawner.GetComponent<StaticTileObjectSpawner>().SpawnStaticTileObject();
		//functionalObjectSpawner.GetComponent<FunctionalObjectSpawner>().SpawnFunctionalObject();
		//playerSpawner.GetComponent<PlayerSpawner>().SpawnPlayer();
	}
}
