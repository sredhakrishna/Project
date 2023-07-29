using Registration.Models;

namespace Registration.Services
{
    public interface IRegisterService
    {
        public IEnumerable<Register> GetRegisterList();
        public Register GetRegisterById(int id);
        public Register AddRegister(Register product);
        public Register UpdateRegister(Register product);
        public bool DeleteRegister(int Id);
    }
}
