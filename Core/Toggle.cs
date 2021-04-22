namespace ModularEffectLib.Core
{
    /// <summary>
    /// Wrapper for an effect toggle
    /// </summary>
    public struct Toggle
    {
        private object Value;

        public bool Get() => Get<bool>();
        public T Get<T>() => Value is T ? (T)Value : default;
    }
}
