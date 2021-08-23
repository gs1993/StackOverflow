using StackOverflow.Application.DTOs.Email;
using System.Threading.Tasks;

namespace StackOverflow.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
