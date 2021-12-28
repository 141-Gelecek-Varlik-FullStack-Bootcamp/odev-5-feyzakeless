using AutoMapper;
using Pharmacy.DB.Entities.DataContext;
using Pharmacy.Model;
using Pharmacy.Model.ModelUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service.Job
{
    public class EmailOperation
    {
        private readonly IMapper mapper; //Mapper çagrildi

        public EmailOperation(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public General<UserViewModel> sendEmail(int id)
        {
            var result = new General<UserViewModel>();
            using (var context = new PharmacyContext())
            {
                var user = context.User.SingleOrDefault(i => i.Id == id);

                if (!user.IsSendEmail)
                {
                    user.IsSendEmail = true;
                    context.SaveChanges();

                    result.Entity = mapper.Map<UserViewModel>(user);

                    result.IsSuccess = true;
                }
            }

            return result;

        }
    }
}
