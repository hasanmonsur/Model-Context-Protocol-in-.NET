namespace MCPWebApi.Models
{
    public static class ModelContext
    {
        private static readonly AsyncLocal<Dictionary<Type, object>> _currentContext = new();

        public static IDictionary<Type, object> Current
        {
            get
            {
                if (_currentContext.Value == null)
                {
                    _currentContext.Value = new Dictionary<Type, object>();
                }
                return _currentContext.Value;
            }
        }

        // Corrected Set method using dictionary indexer
        public static void Set<T>(T value) where T : class
        {
            Current[typeof(T)] = value;
        }

        public static T Get<T>() where T : class
        {
            if (Current.TryGetValue(typeof(T), out var value))
            {
                return (T)value;
            }
            return null;
        }

        public static bool TryGet<T>(out T value) where T : class
        {
            if (Current.TryGetValue(typeof(T), out var obj))
            {
                value = (T)obj;
                return true;
            }
            value = null;
            return false;
        }

        public static void Clear()
        {
            _currentContext.Value?.Clear();
        }
    }
}
