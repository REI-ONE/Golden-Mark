using System.Collections;
using Newtonsoft.Json;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public ChatMessage Prefab;
    public Transform Content;
    public float Delay;
    public TextAsset File;
    [SerializeField]public ChatMessageObject[] Messages;

    private int _index;

    public void Start()
    {
        string str = File.text;
        //Messages = new ChatMessageObject[2] { new ChatMessageObject() { user = "a1", message = "ssa" }, new ChatMessageObject() { user = "b", message = "asas" } };
        //str = JsonConvert.SerializeObject(Messages);
        Messages = JsonConvert.DeserializeObject<ChatMessageObject[]>(File.text);
        StartCoroutine(AddMessage());
    }

    private IEnumerator AddMessage()
    {
        while (_index < Messages.Length)
        {
            ChatMessage message = Instantiate(Prefab, Content);
            message.Init(Messages[_index]);
            yield return new WaitForSeconds(Random.Range(1, Delay));
            message.Show();
            _index++;
        }
    }
}
