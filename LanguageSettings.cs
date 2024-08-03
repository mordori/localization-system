// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using UnityEngine;

/// <summary>
/// Class for handling the game language.
/// </summary>
public class LanguageSettings : MonoBehaviour
{
    // Language objects used to build the language assets.
#if UNITY_EDITOR
    private Localization en = new Strings_en();
    private Localization es = new Strings_es();
    private Localization de = new Strings_de();
    private Localization fr = new Strings_fr();
    private Localization pt = new Strings_pt();
    private Localization ru = new Strings_ru();
    private Localization ko = new Strings_ko();
    private Localization ja = new Strings_ja();
    private Localization zh_s = new Strings_zh_s();
#endif
    
    private LocalizationSaver localizationSaver; // Reads and writes binary language assets to disk.

    public static Localization language; // Holds the current game language asset.

    [SerializeField] private TMPro.TMP_Dropdown dropdown; // Dropdown menu to select the language in game.
    
    // Font assets.
    public static TMPro.TMP_FontAsset currentFont;
    public static TMPro.TMP_FontAsset currentDynamicFont;
    public TMPro.TMP_FontAsset fontEN;
    public TMPro.TMP_FontAsset fontRU;
    public TMPro.TMP_FontAsset fontKO;
    public TMPro.TMP_FontAsset fontJA;
    public TMPro.TMP_FontAsset fontZH_S;

    public enum LANGUAGE
    {
        EN,
        ES,
        DE,
        FR,
        PT,
        RU,
        KO,
        JA,
        ZH_S
    }

    /// <summary>
    /// Sets the initial language value for the dropdown and adds a listener to it for changing the language.
    /// </summary>
    private void Start()
    {
        dropdown.value = (int)GameManager.Instance.saveData.language;
        
        dropdown.onValueChanged.AddListener(
            ChangeLanguage);
    }

    /// <summary>
    /// Languages are initialized and assets are created (Editor only). Game language is set when the game has launched.
    /// and loaded language assets. System language is loaded, if available and not set other otherwise.
    /// </summary>
    /// <param name="saveData">Saved game data</param>
    public void Setup(SaveData saveData)
    {
        language = new Localization();
        language.Initialize();

        localizationSaver = new LocalizationSaver();

#if UNITY_EDITOR
        InitializeLanguages();
#endif

        SetLanguage((int)saveData.language);

        GameManager.Instance.SaveLocal();
    }

    /// <summary>
    /// Saves language object field values as assets, Editor only.
    /// </summary>
    private void InitializeLanguages()
    {
        en.Initialize();
        localizationSaver.Save(en, Strings.language_en);

        ko.Initialize();
        localizationSaver.Save(ko, Strings.language_ko);

        es.Initialize();
        localizationSaver.Save(es, Strings.language_es);

        ja.Initialize();
        localizationSaver.Save(ja, Strings.language_ja);

        ru.Initialize();
        localizationSaver.Save(ru, Strings.language_ru);

        zh_s.Initialize();
        localizationSaver.Save(zh_s, Strings.language_zh_s);

        fr.Initialize();
        localizationSaver.Save(fr, Strings.language_fr);

        de.Initialize();
        localizationSaver.Save(de, Strings.language_de);

        pt.Initialize();
        localizationSaver.Save(pt, Strings.language_pt);
    }

    /// <summary>
    /// Sets the language asset reference from selected dropdown menu index.
    /// </summary>
    /// <param name="index">Dropdown menu index</param>
    private void ChangeLanguage(int index = 0)
    {
        if (index == (int)GameManager.Instance.saveData.language)
            return;

        SetLanguage(index);

        Debug.Log((LANGUAGE)index);
    }
    
    /// <summary>
    /// Sets the language asset reference and refreshes the game language.
    /// </summary>
    /// <param name="index">Language index</param>
    private void SetLanguage(int index = 0)
    {
        var lang = (LANGUAGE)index;
        
        var asset = lang switch
        {
            LANGUAGE.EN => LanguageDataLoader.LanguageData.english,
            LANGUAGE.ES => LanguageDataLoader.LanguageData.spanish,
            LANGUAGE.DE => LanguageDataLoader.LanguageData.german,
            LANGUAGE.FR => LanguageDataLoader.LanguageData.french,
            LANGUAGE.PT => LanguageDataLoader.LanguageData.portuguese,
            LANGUAGE.RU => LanguageDataLoader.LanguageData.russian,
            LANGUAGE.KO => LanguageDataLoader.LanguageData.korean,
            LANGUAGE.JA => LanguageDataLoader.LanguageData.japanese,
            LANGUAGE.ZH_S => LanguageDataLoader.LanguageData.chinese_simplified,
            _ => LanguageDataLoader.LanguageData.english
        };

        localizationSaver.LoadFromAsset(language, asset); // Loads translations from an asset file to the current language.

        GameManager.Instance.saveData.language = lang; // Sets language selection to local save data.

        UIManager.Instance.RefreshLanguage(); // UI Manager calls Set(List<TMPro.TMP_Text>) for the current language with the list of the translatable texts.

        switch (lang)
        {
            case LANGUAGE.EN:
                SetDropdownFontAndLanguage(fontEN, language.english);
                break;
            case LANGUAGE.ES:
                SetDropdownFontAndLanguage(fontEN, language.spanish);
                break;
            case LANGUAGE.DE:
                SetDropdownFontAndLanguage(fontEN, language.german);
                break;
            case LANGUAGE.FR:
                SetDropdownFontAndLanguage(fontEN, language.french);
                break;
            case LANGUAGE.PT:
                SetDropdownFontAndLanguage(fontEN, language.portuguese);
                break;
            case LANGUAGE.RU:
                SetDropdownFontAndLanguage(fontRU, language.russian);
                break;
            case LANGUAGE.KO:
                SetDropdownFontAndLanguage(fontKO, language.korean);
                break;
            case LANGUAGE.JA:
                SetDropdownFontAndLanguage(fontJA, language.japanese);
                break;
            case LANGUAGE.ZH_S:
                SetDropdownFontAndLanguage(fontZH_S, language.chinese_s);
                break;
            default:
                SetDropdownFontAndLanguage(fontEN, language.english);
                break;
        }
    }

    /// <summary>
    /// Sets translated language names and fonts to dropdown menu options.
    /// </summary>
    /// <param name="font">Font asset</param>
    /// <param name="s">Translated language name in current language for the selected option</param>
    private void SetDropdownFontAndLanguage(TMPro.TMP_FontAsset font, string s)
    {
        dropdown.options[0].text = language.english;
        dropdown.options[1].text = language.spanish;
        dropdown.options[2].text = language.german;
        dropdown.options[3].text = language.french;
        dropdown.options[4].text = language.portuguese;
        dropdown.options[5].text = language.russian;
        dropdown.options[6].text = language.korean;
        dropdown.options[7].text = language.japanese;
        dropdown.options[8].text = language.chinese_s;

        dropdown.captionText.text = s;

        dropdown.itemText.font = dropdown.captionText.font = font;
    }
}
