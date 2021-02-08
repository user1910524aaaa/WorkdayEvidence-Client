using System.Threading.Tasks;

namespace Client.Services
{
    public interface IAuthorizationHandlerService
    {
        Task Redirect();
    }
}