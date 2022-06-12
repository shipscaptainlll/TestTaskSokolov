using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    [SerializeField] Transform languagesButtonsHolder;
    bool active = false;

    void Start()
    {
        foreach (Transform languageButton in languagesButtonsHolder)
        {
            if (languageButton.GetComponent<AdditionalUIButton>() != null)
            {
                languageButton.GetComponent<AdditionalUIButton>().languageSelected += ChangeLocale;
            }
        }
    }

    public void ChangeLocale(string languageName)
    {
        if (active == true)
        {
            return;
        }
        StartCoroutine(SetLocale(languageName));
    }

    IEnumerator SetLocale(string languageName)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
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
