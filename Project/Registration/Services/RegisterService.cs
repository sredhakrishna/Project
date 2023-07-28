using Registration.Data;
using Registration.Models;


namespace Registration.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly DbContextClass _dbContext;

        public RegisterService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Register> GetRegisterList()
        {
            return _dbContext.Details.ToList();
        }
        public Register GetRegisterById(int id)
        {
            return _dbContext.Details.Where(x => x.Id == id).FirstOrDefault();
        }

        public Register AddRegister(Register product)
        {
            var result = _dbContext.Details.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Register UpdateRegister(Register product)
        {
            var result = _dbContext.Details.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteRegister(int Id)
        {
            var filteredData = _dbContext.Details.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}