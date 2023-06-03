using UnityEngine;
using System;
using XNode;

[CreateAssetMenu]
public class Dialoque : NodeGraph
{

    public override Node AddNode(Type type)
    {
        Node node = base.AddNode(type);
        DefaultConnection(node as ModelDialoque);
        return node;
    }

    private void DefaultConnection(ModelDialoque curent)
    {
        if (curent == null) return;

        if (nodes.Count > 1)
        {
            curent.ClearConnections();
            ModelDialoque back = nodes[nodes.Count - 2] as ModelDialoque;
            back.GetPort(nameof(back.Finish)).Connect(curent.GetPort(nameof(curent.Start)));
        }
    }
}