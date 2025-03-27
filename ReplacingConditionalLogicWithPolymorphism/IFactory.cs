namespace ReplacingConditionalLogicWithPolymorphism
{
    public interface IFactory<T>
    {
        public T Create();
    }
}
