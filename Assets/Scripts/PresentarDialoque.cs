public interface IPresentar
{
    public void Execute();
}

public class PresentarDialoque : IPresentar
{
    private Dialoque _dialoque;
    private IViewDialoque _view;
    private IModelDialoqueNode _model;

    public PresentarDialoque(Dialoque dialoque, IViewDialoque view)
    {
        _dialoque = dialoque;
        _view = view;
    }

    private void Read()
    {
        _model = _model.Next();

        if (_model == null)
            _view.Call -= Read;

        _view.Show(_model);
    }

    public void Execute()
    {
        _view.Call += Read;
        _model = _dialoque.nodes[0] as IModelDialoqueNode;
        _view.Show(_model);
    }
}