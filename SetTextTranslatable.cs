// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using UnityEngine;

/// <summary>
/// Class that adds the attached TMP text component to a list of texts to be translated.
/// </summary>
public class SetTextTranslatable : MonoBehaviour
{
    private static TMPro.TMP_Text text;

    public void AddTextToTranslatables()
    {
        text = GetComponent<TMPro.TMP_Text>();
        UIManager.Instance.translatableTexts.Add(text); // UI Manager holds the list of all translatable texts.
    }
}
