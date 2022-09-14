using System.Threading.Tasks;

namespace Introspectus.Api.Infrastructure.KeepAlive.Publisher
{
    public interface IKeepAliveEventPublisher
    {
        Task PublishKeepAliveEvent();
    }
}
