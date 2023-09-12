namespace Gameboard
{
    public interface IInputReader<T>
    {
        T[,] ReadInputToGrid();
    }
}