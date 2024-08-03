// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// Class that loads the Addressable language assets. Also calls TranslatablesHandler to find all text objects to be translated
/// and LanguageSettings instance to setup.
/// </summary>
public class LanguageDataLoader : MonoBehaviour
{
    private static LanguageData languageData;
    public static LanguageData LanguageData => languageData;

    private static bool loaded = false;
    public static bool Loaded => loaded;

    /// <summary>
    /// Loads the Addressables language assets referenced in LanguageData ScriptableObject.
    /// </summary>
    /// <returns></returns>
    public static IEnumerator LoadDatabase()
    {
        AsyncOperationHandle<LanguageData> opHandle = Addressables.LoadAssetAsync<LanguageData>("language");
        yield return opHandle;

        languageData = opHandle.Result;

        TranslatablesHandler.CallTranslatables(); // Calls TranslatablesHandler to find all text objects to be translated.
        
        GameManager.Instance.languageSettings.Setup(GameManager.Instance.saveData); // Setups the game language.

        loaded = true;

        Debug.Log("Language data loaded");
    }
}
