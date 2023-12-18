using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LocalizationInstaller : MonoInstaller
{
    [SerializeField] Button _switchLocalButton;

    public override void InstallBindings()
    {
        LocalizationController localizationController = new LocalizationController();
        Container.Bind<LocalizationController>().FromInstance(localizationController).AsSingle();
        _switchLocalButton?.onClick.AddListener(() => localizationController.SwitchLanguage());
    }
}