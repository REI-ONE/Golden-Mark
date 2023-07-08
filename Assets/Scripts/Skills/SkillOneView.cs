using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using Game.Setting;
using UnityEngine;
using Zenject;

public class SkillOneView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private IPause _pause;

    [Inject]
    public void Construct(IPause pause)
    {
        _pause = pause;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Active);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Active);
    }

    private void Active()
    {
        _pause.IsPaused = true;
    }
}