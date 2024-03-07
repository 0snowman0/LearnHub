using LearnHub.Domain.Model.common;
using LearnHub.Domain.Model.Permistion;

namespace LearnHub.Domain.Model.Prifile.Admin
{
    public class AdminProfile_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public List<Permistion_En> permistion_Ens { get; set; } = null!;
    }
}
