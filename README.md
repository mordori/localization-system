Note: This is not a out-of-the-box localization solution, some parts that make it work are not included and it requires manual setup in Editor.

This is a code sample for a game language system for Unity. There are better ways to do it no doubt about it, but this is what I came up with. The motivation was to make the string classes to be easily translated by a machine or a translator, and then simple copy and paste. It loads binary text language assets with Addressables. Why binary you ask? Well, I was learning Addressables and started thinking "What if I would want to distribute the assets remotely? So to make them smaller I should probably use binary format instead of JSON!" I never ended up trying remote distribution and the system is convoluted, but it works so it is what it is.


Gameobjects with TMP texts desired to be translatable are flagged as such by adding a "SetTextTranslatable.cs" component. The name of the translatable Gameobject must match a translatable variable in "Localization.cs".

"LanguageDataLoader.cs" loads the Addressable language assets and calls the "TranslatablesHandler.cs" to find all text objects to be translated when the game is launched.

"LanguageSettings.cs" creates and reads the language assets with "LocalizationSaver.cs", and holds the currently set game language.

"Strings_en.cs" is an example language class, from which a language asset is created.
