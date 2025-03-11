
namespace ArgumentsFlagsAreBad
{
    internal class Program
    {
        private bool _isEnabled;
        private Effect _effects;
        private Pool _pool;

        private static void Main()
        {
            Console.WriteLine("Hello, World!");
        }

        public void Enable()
        {
            _isEnabled = true;
            _effects.Enable();
        }

        public void Disable()
        {
            _isEnabled = false;
            _pool.Free(this);
        }
    }

    internal class Pool
    {
        internal void Free(object @object)
        {
            throw new NotImplementedException();
        }
    }

    internal class Effect
    {
        internal void Enable()
        {
            throw new NotImplementedException();
        }
    }
}
