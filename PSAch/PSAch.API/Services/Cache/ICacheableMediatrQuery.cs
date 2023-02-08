namespace PSAch.API.Services.Cache
{
    public interface ICacheableMediatrQuery
    {
        /// <summary>
        /// Определяет должны ли мы пропусти кэширование и обратиться сразу к базе данных
        /// </summary>
        bool BypassCache { get; }

        /// <summary>
        /// Уникальный ключ для каждого запроса
        /// </summary>
        string CacheKey { get; }

        /// <summary>
        /// Время в ч. хранения 
        /// </summary>
        TimeSpan? SlidingExpiration { get; }
    }
}
