using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Workers;
using api.Models;

namespace api.Mappers
{
    public static class WorkersMapper
    {
        public static WorkersDto ToWorkersDto (this Workers_On_Ticket WorkersModel)
        {
            return new WorkersDto
            {
                Id = WorkersModel.Id,
                Service_Workers_Quantity = WorkersModel.Service_Workers_Quantity
            }; 
        }

        public static Workers_On_Ticket ToWorkersFromCreateDTO(this CreateWorkersRequestDto workersDto)
        {
            return new Workers_On_Ticket
            {
                Service_Workers_Quantity = workersDto.Service_Workers_Quantity
            };
        }

        public static Workers_On_Ticket ToWorkersFromUpdateDto(this UpdateWorkersRequestDto workersDto, Workers_On_Ticket existingWorkers)
        {
            return new Workers_On_Ticket
            {
                Service_Workers_Quantity = workersDto.Service_Workers_Quantity == 0 ? existingWorkers.Service_Workers_Quantity : workersDto.Service_Workers_Quantity
            };
        }
    }
}