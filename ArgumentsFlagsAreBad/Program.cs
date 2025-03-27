namespace ArgumentsFlagsAreBad
{
    internal class Program
    {
        private bool _isEnabled;
        private Effect _effects;
        private Pool _pool;

        private static void Main() { }

        public void Enable()
        {
            _effects.Enable();
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
            _pool.Free(this);
        }
    }

    public class Pool
    {
        public void Free(object @object) =>
            ArgumentNullException.ThrowIfNull(@object);
    }

    public class Effect
    {
        public void Enable() { }
    }
}
