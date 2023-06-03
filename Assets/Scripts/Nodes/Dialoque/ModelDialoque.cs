using UnityEngine;
using XNode;

[NodeWidth(300)]
public class BaseNode : Node
{
    [Input]
    public bool Start;

    [Output]
    public bool Finish;

    // Use this for initialization
    protected override void Init()
    {
        base.Init();
    }

    // Return the correct value of an output port when requested
    public override object GetValue(NodePort port)
    {
        return null; // Replace this
    }
}

public interface IModelDialoque
{
    public string Name { get; }
    public string Speech { get; }
}

public interface IModelDialoqueNode : IModelDialoque
{
    public IModelDialoqueNode Back();
    public IModelDialoqueNode Next();
}

public class ModelDialoque : BaseNode, IModelDialoqueNode
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField, TextArea(10, 5)]
    public string Speech { get; private set; }

    public IModelDialoqueNode Back()
    {
        NodePort back = GetPort(nameof(Start));

        return back.Connection != null ? back.Connection.node as IModelDialoqueNode : null;
    }

    public IModelDialoqueNode Next()
    {
        NodePort next = GetPort(nameof(Finish));

        return next.Connection != null ? next.Connection.node as IModelDialoqueNode : null;
    }
}