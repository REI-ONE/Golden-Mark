using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationController
{
    public void SwitchLanguage()
    {
        var locales = LocalizationSettings.AvailableLocales.Locales;
        var currentLocale = LocalizationSettings.SelectedLocale;
        var nextLocaleIndex = (locales.IndexOf(currentLocale) + 1) % locales.Count;
        var nextLocale = locales[nextLocaleIndex];
        LocalizationSettings.SelectedLocale = nextLocale;
    }

    public void ChangeLanguage(string languageIdentifier)
    {
        var localeCode = new LocaleIdentifier(languageIdentifier);

        LocalizationSettings.AvailableLocales.Locales.ForEach(locale =>
        {
            var localeIdentifier = locale.Identifier;
            if (localeIdentifier == localeCode)
                LocalizationSettings.SelectedLocale = locale;
        });
    }
}
