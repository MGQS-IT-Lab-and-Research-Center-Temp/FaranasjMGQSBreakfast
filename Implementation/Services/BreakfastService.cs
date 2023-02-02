using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Models;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Implementation.Services
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IBreakfastRepository _breakfastRepository;

        public BreakfastService(ApplicationDbContext context, IBreakfastRepository breakfastRepository)
        {
            _breakfastRepository = breakfastRepository;
        }
        public BreakfastResponseModel DeleteBreakfast(int id)
        {
            var breakfast = _breakfastRepository.GetById(id);
            
            if(breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast Not found!!",
                    Status = false
                };
            }

            var isDeleted = _breakfastRepository.Delete(id);

            if (isDeleted == true)
            {
                return new BreakfastResponseModel
                { 
                    Message = "BreakFast Succesfully deleted",
                    Status = true
                };
            }

            return new BreakfastResponseModel
            {
                Message = "Unable to delete breakfast",
                Status = false
            };
            
        }
        public BreakfastResponseModel CreateBreakfast(CreateBreakfastViewModel request)
        {
            throw new NotImplementedException();
        }
        public BreakfastResponseModel GetAllBreakfast(BreakfastViewModel breakFast)
        {
            throw new NotImplementedException();
        }

        public BreakfastResponseModel GetBreakfast(int id)
        {
            var breakfast = _breakfastRepository.GetById(id);
            if (breakfast == null )
            {
                return new BreakfastResponseModel
                {
                    Message = "BreakFast not found!!",
                    Status = false
                };
            }

            return new BreakfastResponseModel
                {
                    Data = new BreakfastViewModel
                    {
                        Id = breakfast.Id,
                        Name = breakfast.Name,
                        Description = breakfast.Description,
                        StartDateTime = breakfast.StartDateTime,
                        EndDateTime = breakfast.EndDateTime
                    },
                    
                    Status = true,
                    Message = "BreakFast successfully retrieved"
                };
        }
        public BreakfastResponseModel UpdateBreakfast(int id, UpdateBreakfastViewModel request)
        {
            var breakfast = _breakfastRepository.GetById(id);
            if(breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = false
                };
            }
            
            breakfast.Name = request.Name;
            breakfast.Description = request.Description;
            breakfast.StartDateTime = request.StartDateTime;
            breakfast.EndDateTime = request.EndDateTime;

            _breakfastRepository.Update(breakfast.Id);
            return new BreakfastResponseModel
                {
                    Message= "BreakFast successfully updated",
                    Status =  true
                };
        }
    }
}