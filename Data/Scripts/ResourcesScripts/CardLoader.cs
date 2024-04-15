using Godot;
using System;
using System.Collections.Generic;
using System.IO;

public partial class CardLoader : Node
{
	// Обобщенный метод для загрузки ресурсов типа T из указанной директории
	public static List<CardData> Load(string dirPath)
	{
		// Список для хранения загруженных ресурсов.
		List<CardData> loadedCards = new List<CardData>();

		// Если путь к директории null или пуст, возвращаем пустой список
		if (string.IsNullOrEmpty(dirPath))
		{
			return loadedCards;
		}

		// Открываем директорию
		using (var dir = DirAccess.Open(dirPath))
		{
			// Проверяем, успешно ли удалось открыть директорию
			if (dir != null)
			{
				// Начинаем перечисление содержимого директории
				dir.ListDirBegin();

				// Получаем имя первого файла в директории
				string fileName = dir.GetNext();

				// Итерируемся по всем файлам в директории
				while (fileName != "")
				{
					// Проверяем, имеет ли файл расширение ".tres"
					if (fileName.Contains(".tres"))
					{
						// Строим полный путь к файлу ресурса
						string resourcePath = Path.Combine(dir.GetCurrentDir(), fileName);

						// Загружаем ресурс с использованием ResourceLoader
						Resource loadedResource = ResourceLoader.Load(resourcePath);

						try
						{
							loadedCards.Add(loadedResource as CardData);
						}						
						catch
						{
							GD.Print($"Ошибка: Невозможно привести ресурс {resourcePath} к типу CardData.");
						}
					}

					// Получаем имя следующего файла в директории
					fileName = dir.GetNext();
				}

				// Завершаем перечисление директории
				dir.ListDirEnd();
			}
			else
			{
				// Выводим сообщение об ошибке, если директорию не удалось открыть
				GD.Print($"Ошибка в получении пути к папке: {dirPath}");
			}

			// Возвращаем список загруженных ресурсов
			return loadedCards;
		}
	}
}
