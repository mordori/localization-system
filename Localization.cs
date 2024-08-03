// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Base class for language classes.
/// </summary>
public class Localization
{
    // Translatable text fields.
#region Fields
    public string date_month_1;
    public string date_month_2;
    public string date_month_3;
    public string date_month_4;
    public string date_month_5;
    public string date_month_6;
    public string date_month_7;
    public string date_month_8;
    public string date_month_9;
    public string date_month_10;
    public string date_month_11;
    public string date_month_12;

    public string english;
    public string spanish;
    public string russian;
    public string japanese;
    public string french;
    public string german;
    public string korean;
    public string chinese_s;
    public string portuguese;

    public string you;
    public string global;
    public string friends;
    public string ok;
    public string yes;
    public string no;
    public string select;
    public string unlock;
    public string coins;
    public string gems;
    public string equip;
    public string upgrade;
    public string buy;
    public string cancel;
    public string info;

    public string credits;
    public string game;
    public string audio;
    public string graphics;
    public string unlimited;
    public string controls;
    public string scores;
    public string start;

    public string developed_by;
    public string special_thanks;
    public string thank_you_1;
    public string thank_you_2;

    public string play;
    public string gear;
    public string revive;
    public string quit;
    public string paused;
    public string skins;
    public string new_items;

    public string sign_in_info;
    public string sign_in;
    public string signing_in;
    public string sign_in_tos;
    public string sign_in_privacy;

    public string store;
    public string customize;
    public string settings;
    public string settings_game;
    public string settings_graphics;
    public string settings_audio;
    public string tutorial;
    public string highscores;
    public string highscores_friends;
    public string highscores_global;
    public string achievements;
    public string language;
    public string invert_game_UI;
    public string mute_audio;
    public string volume;
    public string music;
    public string sound_effects;
    public string ambience;

    public string store_ads_info;
    public string store_item_ads;
    public string store_purchase_failed;
    public string store_purchase_success;
    public string store_purchase_item_1;
    public string store_purchase_item_2;

    public string ads_remove;
    public string ads_watch;

    public string gear_use_info;
    public string gear_upgrade_info;

    public string countdown_ready;
    public string countdown_go;
    public string countdown_start;

    public string score_new;
    public string score_try;
    public string score_nice;
    public string score_wow;
    public string score_mega;
    public string score_amazing;
    public string score_super;
    public string score_god;
    
    public string graphics_low;
    public string graphics_default;
    public string graphics_high;

    public string music_by;
    public string published_by;

    public string sign_in_error;
    public string loading;
    public string quality;
    public string agree;
    public string continu;
#endregion

    /// <summary>
    /// Initializes the translatable fields with an empty string. Used to check, if corresponding translations exist.
    /// </summary>
    public virtual void Initialize()
    {
        // Determines which types of fields are used.
        var bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public;

        // Gets the fields and puts them to a list.
        var values = GetType()
                    .GetFields(bindingFlags)
                    .Select(field => field)
                    .ToList();

        foreach (var field in values)
        {
            field.SetValue(this, "");
        }
    }

    /// <summary>
    /// Sets translations to TMP text objects.
    /// </summary>
    /// <param name="list">List of translatable TMP text GameObjects</param>
    public void Set(List<TMPro.TMP_Text> list)
    {
        var bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public;

        // Gets the field names from current language and puts them to a list.
        var names = GetType()
                    .GetFields(bindingFlags)
                    .Select(field => field.Name)
                    .ToList();

        // Gets the string values as objects from current language and puts them to a list.
        var values = GetType()
                    .GetFields(bindingFlags)
                    .Select(field => field.GetValue(this))
                    .ToList();

        Dictionary<string, string> d = new Dictionary<string, string>();
        
        // Stores field names and values to a dictionary and checks, if corresponding translations are written.
        for (int i = 0; i < names.Count; i++)
        {
#if UNITY_EDITOR
            if (values[i].Equals("")) Debug.LogError($"{names[i]} is not set in {LanguageSettings.language}");
#endif

            d.Add(names[i], (string)values[i]);
        }

        // Assigns baked and dynamic TMP font assets.
        //TODO: Switch to baked fonts
        TMPro.TMP_FontAsset f = GameManager.Instance.languageSettings.fontEN;
        TMPro.TMP_FontAsset fDynamic = GameManager.Instance.languageSettings.fontEN;

        switch (GameManager.Instance.saveData.language)
        {
            case LanguageSettings.LANGUAGE.EN:
            case LanguageSettings.LANGUAGE.ES:
            case LanguageSettings.LANGUAGE.DE:
            case LanguageSettings.LANGUAGE.FR:
            case LanguageSettings.LANGUAGE.PT:
                f = GameManager.Instance.languageSettings.fontEN;
                fDynamic = GameManager.Instance.languageSettings.fontEN;
                break;
            case GameSettings.LANGUAGE.RU:
                f = GameManager.Instance.languageSettings.fontRU;
                fDynamic = GameManager.Instance.languageSettings.fontRU;
                break;
            case GameSettings.LANGUAGE.KO:
                f = GameManager.Instance.languageSettings.fontKO;
                fDynamic = GameManager.Instance.languageSettings.fontKO;
                break;
            case GameSettings.LANGUAGE.ZH_S:
                f = GameManager.Instance.languageSettings.fontZH_S;
                fDynamic = GameManager.Instance.languageSettings.fontZH_S;
                break;
            case GameSettings.LANGUAGE.JA:
                f = GameManager.Instance.languageSettings.fontJA;
                fDynamic = GameManager.Instance.languageSettings.fontJA;
                break;
        }

        LanguageSettings.currentFont = f;
        LanguageSettings.currentDynamicFont = fDynamic;

        // Sets the translated value to the TMP text by comparing its GameObject's name with a matching dictionary key field name.
        foreach (TMPro.TMP_Text t in list)
        {
            if (d.TryGetValue(t.name, out var value))
            {
                TweenText tweener = t.gameObject.GetComponent<TweenText>();
                if (tweener != null && !tweener.isStarted) tweener.enabled = false;

                t.text = value;

                t.enableAutoSizing = true;
                //t.fontSizeMin = 5f;
                //t.fontSizeMax = 80f;

                if (tweener != null && !tweener.isStarted)
                {
                    tweener.isSizeSet = false;
                    tweener.SetTextSize();
                    tweener.enabled = true;
                }
               
                t.font = f;
            }
            else
            {
                Debug.LogError($"{t.name} translatable text error!");
            }
        }
    }
}
