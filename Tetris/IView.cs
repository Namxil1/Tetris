namespace Tetris
{
    internal interface IView
    {
        IModel Model { get; set; }
        IController Controller { get ; set; }

    }
}