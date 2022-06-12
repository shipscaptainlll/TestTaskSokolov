using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    static bool active = false;
    
    public static void ChangeLocale(string languageName)
    {
        if (active == true)
        {
            return;
        }
        active = true;
        int localeID = 0;
        switch (languageName)
        {
            case "czechLanguage":
                localeID = 0;
                break;
            case "englishLanguage":
                localeID = 1;
                break;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        active = false;
    }
}
