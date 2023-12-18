using UnityEngine;
using System;

public interface IView
{
    public Type Owner { get; }

    public void SetPresentar(Type presentar);
    public void Show();
    public void Hide();
}

public class View : MonoBehaviour, IView
{
    public Type Owner { get; protected set; }

    public void SetPresentar(Type presentar) => Owner = presentar;
    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);
}