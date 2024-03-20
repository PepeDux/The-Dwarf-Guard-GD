using Godot;
using System;

public partial class Spawner : Node2D
{
    // Random ������ ��� ��������� ��������� �����
    private Random random = new Random();

    // ���������� ������
    private Vector2I spawnCoordinate;

    // ���������� � ������
    public LevelInfo levelInfo;

    // ���������� ��� ���������� ����
    public override void _Ready()
    {
        // �������� ���������� �� ������ ��� ����������
        levelInfo = GetLevelInfo();
    }

    // ����� ��� ������ ��������
    public void Spawn(PackedScene[] spawnableScenes, Vector2I spawnPosition)
    {
        // ���� ��� �������� ��� ������, �������
        if (spawnableScenes.Length == 0)
        {
            return;
        }

        // ���� ������� ������ �� �������, ������� �� ��������� ����������
        if (spawnPosition == Vector2I.Zero)
        {
            TrySpawnWithRandomCoordinate(spawnableScenes);
        }
        else
        {
            // ����� ������� �� ��������� �������
            TrySpawnAtPosition(spawnableScenes, spawnPosition);
        }
    }

    // ������� ������ �� ��������� ����������
    private void TrySpawnWithRandomCoordinate(PackedScene[] spawnableScenes)
    {
        // ������� �������� 20 ���
        for (int i = 0; i < 20; i++)
        {
            if (TryGetRandomCoordinate())
            {
                // ���� ������� �������� ����������, ������� ������ �� ���
                SpawnObject(spawnableScenes[random.Next(0, spawnableScenes.Length)]);
                break;
            }
        }
    }

    // ��������� ��������� ��������� ����������
    private bool TryGetRandomCoordinate()
    {
        spawnCoordinate = GetRandomFreeCoordinate();
        return IsCoordinateAvailable(spawnCoordinate);
    }

    // ������� ������ �� ��������� �������
    private void TrySpawnAtPosition(PackedScene[] spawnableScenes, Vector2I spawnPosition)
    {
        SpawnObject(spawnableScenes[random.Next(0, spawnableScenes.Length)]);
    }

    // ��������� ��������� ��������� ����������
    private Vector2I GetRandomFreeCoordinate()
    {
        return TileStorage.freeCells[random.Next(0, TileStorage.freeCells.Count)];
    }

    // �������� ����������� ���������� ��� ������
    private bool IsCoordinateAvailable(Vector2I coordinate)
    {
        return TileStorage.freeCells.Contains(coordinate) && !TileStorage.occupiedCells.Contains(coordinate);
    }

    // ����� �������
    private void SpawnObject(PackedScene scene)
    {
        // ������������� ����� � ��������� ������ �� �����
        BaseObject node = (BaseObject)scene.Instantiate();
        node.coordinate = spawnCoordinate;
        AddChild(node);
    }

    // ��������� ���������� �� ������
    private LevelInfo GetLevelInfo()
    {
        // �������� ���������� �� ������ �� ��������� ���� �����
        return GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
    }
}