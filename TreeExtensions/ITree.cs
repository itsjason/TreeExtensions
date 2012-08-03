namespace TreeExtensions
{
    public interface ITree<T>
    {
        T[] Children { get; set; }
    }
}