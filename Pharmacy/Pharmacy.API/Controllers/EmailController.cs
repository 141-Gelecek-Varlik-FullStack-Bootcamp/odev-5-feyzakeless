using AutoMapper;
using Pharmacy.Service.UserServiceLayer;

namespace Pharmacy.API.Controllers
{
    public class EmailController 
    {
        private readonly IUserService userService; //User service i çağırıyoruz.
        private readonly IMapper mapper;

        public EmailController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }
        
    }
}
