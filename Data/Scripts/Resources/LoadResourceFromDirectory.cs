using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class LoadResourceFromDirectory : Node
{
    // Обобщенный метод для загрузки ресурсов типа T из указанной директории
    public static List<T> Load<T>(string dirPath)
    {
        // Список для хранения загруженных ресурсов.
        List<Resource> loadedResources = new List<Resource>();

        // Если путь к директории null или пуст, возвращаем пустой список
        if (string.IsNullOrEmpty(dirPath))
        {
            return loadedResources.Cast<T>().ToList();
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
                        string resourcePath = Path.Join(dir.GetCurrentDir(), fileName);

                        // Загружаем ресурс с использованием ResourceLoadert
                        Resource resource = ResourceLoader.Load<Resource>(resourcePath);

                        // Добавляем загруженный ресурс в список
                        loadedResources.Add(resource);
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

            // Преобразуем список загруженных ресурсов к указанному типу T и возвращаем его
            return loadedResources.Cast<T>().ToList();
        }
    }
}
