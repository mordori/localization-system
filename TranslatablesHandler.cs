// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using UnityEngine;

/// <summary>
/// Class that finds every TMP text flagged to be translated.
/// </summary>
public class TranslatablesHandler: MonoBehaviour
{
    public static void CallTranslatables()
    {
        SetTextTranslatable[] array = FindObjectsOfType<SetTextTranslatable>(true);

        foreach (SetTextTranslatable t in array)
        {
            t.AddTextToTranslatables();
        }
    }
}