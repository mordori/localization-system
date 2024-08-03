// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using UnityEngine;
using System.IO;
using System.Reflection;
using System.Linq;

/// <summary>
/// Class that creates and reads the language assets.
/// </summary>
public class LocalizationSaver
{
    private static string filename;

    /// <summary>
    /// Gets the path for a language asset file on disk.
    /// </summary>
    /// <returns>Path to a language asset file</returns>
    private static string GetSaveFilePath()
    {
        string path = $"{Application.dataPath}/Bundles/Languages";

        try
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }
        catch (IOException e)
        {
            Debug.LogError(e.Message);
        }

        return $"{path}/{filename}";
    }

    /// <summary>
    /// Saves a language asset file on disk in binary format to be used with Addressables.
    /// </summary>
    /// <param name="data">Language class</param>
    /// <param name="file">Language file name</param>
    public void Save(Localization data, string file)
    {
        filename = file;

        using var writer = new BinaryWriter(new FileStream(GetSaveFilePath(), FileMode.OpenOrCreate));
        
        try
        {
            // Determines which types of fields are used.
            var bindingFlags = BindingFlags.Instance |
                               BindingFlags.NonPublic |
                               BindingFlags.Public;

            // Gets all the string values as objects from a language object and puts them to a list.
            var values = data.GetType()
                .GetFields(bindingFlags)
                .Select(field => field.GetValue(data))
                .ToList();

            foreach (string s in values)
            {
                writer.Write(s);
                //Debug.Log(s);
            }

        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"Saving language {file} data failed.\n{e.Message}\n");
        }

        Debug.LogWarning($"Save language {file} complete.\n");
    }

    /// <summary>
    /// Loads language data to current language from a language asset.
    /// </summary>
    /// <param name="data">Current language reference</param>
    /// <param name="asset">Language asset</param>
    public void LoadFromAsset(Localization data, TextAsset asset)
    {
        byte[] bytes = asset.bytes;

        using var stream = new MemoryStream(bytes);
        using var reader = new BinaryReader(stream);
        
        try
        {
            var bindingFlags = BindingFlags.Instance |
                               BindingFlags.NonPublic |
                               BindingFlags.Public;

            // Gets the fields from current language and puts them to a list.
            var values = data.GetType()
                .GetFields(bindingFlags)
                .Select(field => field)
                .ToList();

            foreach (var field in values)
            {
                field.SetValue(data, reader.ReadString());
                //Debug.Log($"{field.Name} : {field.GetValue(LanguageSettings.language)}");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"Language {asset.name} data is corrupted.\n");
        }
    }
}
