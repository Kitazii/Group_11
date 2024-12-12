using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Service;
using api.Models;

namespace api.Mappers
{
    //Used to map Data Transfer Objects to our business logic models
    //Ensuring a smooth transition, when throwing objects to our end points
    public static class ServiceMapper
    {
        public static ServiceDto ToServiceDto (this MyService serviceModel)
        {
            return new ServiceDto
            {
                Id = serviceModel.Id,
                Service_Type = serviceModel.Service_Type,
                Service_Description = serviceModel.Service_Description,
                Service_Cost = serviceModel.Service_Cost,
                Workers = serviceModel.Workers.Select(w => w.ToWorkersDto()).ToList()
            };
        }

        public static MyService ToServiceFromCreateDto (this CreateServiceRequestDto serviceDto)
        {
            return new MyService
            {
                Service_Type = serviceDto.Service_Type,
                Service_Description = serviceDto.Service_Description,
                Service_Cost = serviceDto.Service_Cost
            };
        }

        public static MyService ToServiceFromUpdateDto (this UpdateServiceRequestDto serviceDto, MyService existingService)
        {
            return new MyService
            {
                Service_Type = string.IsNullOrWhiteSpace(serviceDto.Service_Type) ? existingService.Service_Type : serviceDto.Service_Type,
                Service_Description = string.IsNullOrWhiteSpace(serviceDto.Service_Description) ? existingService.Service_Description : serviceDto.Service_Description,
                Service_Cost = (serviceDto.Service_Cost <= 0.00m) ? existingService.Service_Cost : serviceDto.Service_Cost
            };
        }
    }
}