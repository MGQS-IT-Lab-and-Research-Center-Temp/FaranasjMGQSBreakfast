using MGQSBreakfast.Entities;

namespace MGQSBreakfast.Contracts.Repositories
{
    public interface IBreakfastRepository
    {
        Breakfast Create(Breakfast breakfast);
        Breakfast GetById(int id);
        List<Breakfast> GetAll();
        Breakfast Update(int id);
        bool Delete(int id);
        bool BreakfastExist(int id);
        bool BreakfastExist(string name);
    }
}