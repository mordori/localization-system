// Copyright© 2024 Mika Yli-Pentti. All rights reserved.

/// <summary>
/// Class for English language.
/// </summary>
public class Strings_en : Localization
{
    public override void Initialize()
    {
        base.Initialize();

        //Months
        //-----------------------------------
        date_month_1 = "January";
        date_month_2 = "February";
        date_month_3 = "March";
        date_month_4 = "April";
        date_month_5 = "May";
        date_month_6 = "June";
        date_month_7 = "July";
        date_month_8 = "August";
        date_month_9 = "September";
        date_month_10 = "October";
        date_month_11 = "November";
        date_month_12 = "December";

        //Languages
        //-----------------------------------
        english = "english";
        german = "german";
        japanese = "japanese";
        korean = "korean";
        chinese_s = "chinese-simplified";
        french = "french";
        spanish = "spanish";
        russian = "russian";
        portuguese = "portuguese";

        //Main Menu
        //-----------------------------------
        store = "Store";
        ads_remove = "Remove ads from revive!";
        gear = "Gear";
        play = "Play!";
        skins = "Skins";
        new_items = "New";

        //Start
        //-----------------------------------
        scores = "Leaderboard";
        start = "Start!";
        countdown_ready = "READY?";
        countdown_go = "GO!";
        countdown_start = "START!";

        score_new = "New highscore!";
        score_try = "Go again!";
        score_nice = "Nice score!";
        score_mega = "Mega score!";
        score_wow = "Super score!";
        score_super = "Super Mega Nice score!";
        score_amazing = "Amazing!";
        score_god = "Godlike score!";

        //Menu
        //-----------------------------------
        settings = "Settings";
        achievements = "Achievements";
        tutorial = "Tutorial";
        quit = "Quit";
        thank_you_1 = "Thank you for playing!";

        //Currency Store
        //-----------------------------------
        coins = "Coins";
        gems = "Gems";
        buy = "Buy";
        cancel = "Cancel";
        store_ads_info = "Remove ads from revive forever with one-time purchase of Gems for $4.99 or $9.99!";
        store_purchase_failed = "Something went wrong. Please try again later.";
        store_purchase_success = "Success! You received:";
        store_item_ads = "No ads forever! <3";
        store_purchase_item_1 = "Purchase";
        store_purchase_item_2 = "with";

        //Settings
        //-----------------------------------
        language = "Language";
        invert_game_UI = "Invert game UI";
        mute_audio = "Mute audio";
        volume = "Volume";
        credits = "Credits";
        music = "Music";
        ambience = "Ambience";
        sound_effects = "Sound effects";
        game = "Game";
        customize = "Customize";
        audio = "Audio";
        graphics = "Graphics";
        unlimited = "Unlimited";
        controls = "Controls";
        developed_by = "Developed by";
        thank_you_2 = "Thank you for playing our game!";
        special_thanks = "Special thanks";
        settings_game = "Settings: Game";
        settings_graphics = "Settings: Graphics";
        settings_audio = "Settings: Audio";

        //Skins
        //-----------------------------------
        select = "Select";
        unlock = "Unlock";

        //Revive
        //-----------------------------------
        ads_watch = "Watch a short ad to continue the run!";
        revive = "Revive";

        //Scores
        //-----------------------------------
        global = "Global";
        friends = "Friends";
        you = "You";
        highscores = "Highscores";
        highscores_friends = "Highscores: Friends";
        highscores_global = "Highscores: Global";

        //Gear Store
        //-----------------------------------
        equip = "Equip";
        upgrade = "Upgrade";
        gear_use_info = "Use Coins to buy Gear. You can equip Gear and use it once during a run. Special Gear(*) is used automatically at the start of a run.";
        gear_upgrade_info = "Upgrade the power of your Gear using Coins.";

        //Splash Screen
        //-----------------------------------
        sign_in = "Sign in";
        signing_in = "Signing in";
        sign_in_error = "Error in signing in. Please try again in a few minutes.";
        sign_in_info = $"By continuing you accept the terms of service below.";
        sign_in_tos = $"<link={Strings.link_tos}>Terms of Service</color></link>";
        sign_in_privacy = $"<link={Strings.link_privacy}>Privacy Policy</color></link>";

        //Pause
        //-----------------------------------
        paused = "PAUSED";

        //Other
        //-----------------------------------
        ok = "OK";
        yes = "Yes";
        no = "No";
        
        music_by = "Music by";
        published_by = "";
        graphics_low = "";
        graphics_default = "";
        graphics_high = "";

        info = "Info";
        loading = "Loading";
        quality = "Rendering quality";
        agree = "Agree";
        continu = "Continue";
    }
}
