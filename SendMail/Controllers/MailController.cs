using MailService.Models;
using Microsoft.AspNetCore.Mvc;
using SendMail.Services;

namespace SendMail.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private ISendService sendService;
        public MailController(ISendService sendService){
            this.sendService = sendService;
        }
        

        [HttpPost]
        public void SendMail(MailData mail){
            sendService.SendMail(mail);
            
        } 
    }
}