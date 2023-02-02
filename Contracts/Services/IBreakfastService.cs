using MGQSBreakfast.Models;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Contracts.Services
{
    public interface IBreakfastService
    {
        BreakfastResponseModel CreateBreakfast(CreateBreakfastViewModel request);
        BreakfastResponseModel GetBreakfast(int id);
        BreakfastResponseModel DeleteBreakfast(int id);
        BreakfastResponseModel UpdateBreakfast(int id, UpdateBreakfastViewModel request);
        BreakfastResponseModel GetAllBreakfast(BreakfastViewModel breakfast);
    }
}