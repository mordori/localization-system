// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using UnityEngine;

/// <summary>
/// ScriptableObject that references all the language assets.
/// </summary>
[CreateAssetMenu(fileName = "LanguageData", menuName = "Language Data")]
public class LanguageData : ScriptableObject
{
    public TextAsset english;
    public TextAsset spanish;
    public TextAsset russian;
    public TextAsset korean;
    public TextAsset chinese_simplified;
    public TextAsset japanese;
    public TextAsset french;
    public TextAsset german;
    public TextAsset portuguese;
}
