using UnityEngine;
using System;
using TMPro;

public interface IViewDialoque
{
    public event Action Call;
    public void Show(IModelDialoque model);
    public void Next();
    public void Hide();
}

public class ViewDialoque : MonoBehaviour, IViewDialoque
{
    [SerializeField] private Canvas _window;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _speech;

    public event Action Call;

    public void Show(IModelDialoque model)
    {
        if (model == null)
        {
            Hide();
            return;
        }

        _window.enabled = true;
        _name.SetText(model.Name);
        _speech.SetText(model.Speech);
    }

    public void Next() => Call?.Invoke();

    public void Hide()
    {
        _window.enabled = false;
        _name.SetText("");
        _speech.SetText("");
    }

}