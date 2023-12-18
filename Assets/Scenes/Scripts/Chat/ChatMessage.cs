using UnityEngine;
using System;
using TMPro;

[Serializable]
public struct ChatMessageObject
{
    [SerializeField] public string user;
    [SerializeField] public string message;
}

public class ChatMessage : View
{
    public TextMeshProUGUI User;
    public TextMeshProUGUI Message;

    public void Init(ChatMessageObject chatMessageObject)
    {
        User.SetText(chatMessageObject.user);
        Message.SetText(chatMessageObject.message);
    }
}