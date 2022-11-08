namespace CS_LABS.INTERFACES;

public interface IVector<T> {
    public T Peek();
    public void Clear();
    public bool Contains(T value);
}