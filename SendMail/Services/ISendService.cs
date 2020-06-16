using System.Threading.Tasks;
using MailService.Models;
namespace SendMail.Services
{
    public interface ISendService
    {
         public Task SendMail(MailData mail);
    }
}