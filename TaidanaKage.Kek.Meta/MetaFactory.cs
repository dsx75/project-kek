namespace TaidanaKage.Kek.Meta
{
    /// <summary>
    /// Meta Factory.
    /// </summary>
    public static class MetaFactory
    {
        private static IMeta? _meta;

        /// <summary>
        /// Meta.
        /// <br/>
        /// This is the single instance of Meta for the whole application.
        /// </summary>
        public static IMeta Meta
        {
            get
            {
                // TODO This is not thread-safe!
                if (_meta == null)
                {
                    _meta = new MyMeta();
                }
                return _meta;
            }
        }

    }
}