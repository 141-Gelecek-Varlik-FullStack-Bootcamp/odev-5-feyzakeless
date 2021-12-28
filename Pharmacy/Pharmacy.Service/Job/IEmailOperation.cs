using Pharmacy.Model;
using Pharmacy.Model.ModelUser;

namespace Pharmacy.Service.Job
{
    public interface IEmailOperation
    {
        public General<UserViewModel> sendEmail(int id);
    }
}
