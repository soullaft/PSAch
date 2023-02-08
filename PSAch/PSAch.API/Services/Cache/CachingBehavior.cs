using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text;
using System.Threading;

namespace PSAch.API.Services.Cache
{
    public sealed class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheableMediatrQuery
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly CacheSettings _settings;
        
        public CachingBehavior(IDistributedCache cache, ILogger<TResponse> logger, IOptions<CacheSettings> settings)
        {
            _cache = cache;
            _logger = logger;
            _settings = settings.Value;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            //переходим дальше, если ответ предполагает пропуск кеширования
            if (request.BypassCache) return await next();

            var cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                _logger.LogInformation($"Fetched from Cache -> '{request.CacheKey}'.");
            }
            else
            {
                response = await GetResponseAndAddToCache(request, cancellationToken, next);
                _logger.LogInformation($"Added to Cache -> '{request.CacheKey}'.");
            }
            
            return response;
        }

        private async Task<TResponse> GetResponseAndAddToCache(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //получаем ответ
            var response = await next();
            //получаем время хранения ответа
            var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromHours(_settings.SlidingExpiration) : request.SlidingExpiration;
            var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
            //сериализуем ответ
            var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
            await _cache.SetAsync(request.CacheKey, serializedData, options, cancellationToken);
            return response;
        }
    }
}
