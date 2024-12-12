using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Workers;
using api.Models;

namespace api.Mappers
{
    //Used to map Data Transfer Objects to our business logic models
    //Ensuring a smooth transition, when throwing objects to our end points
    public static class WorkersMapper
    {
        public static WorkersDto ToWorkersDto (this Workers_On_Ticket workersModel)
        {
            return new WorkersDto
            {
                Id = workersModel.Id,
                Service_Workers_Quantity = workersModel.Service_Workers_Quantity,
                ServiceId = workersModel.ServiceId,
                TicketId = workersModel.TicketId
            }; 
        }

        public static Workers_On_Ticket ToWorkersFromCreateDTO(this CreateWorkersRequestDto workersDto, int serviceId, int ticketId)
        {
            return new Workers_On_Ticket
            {
                Service_Workers_Quantity = workersDto.Service_Workers_Quantity,
                ServiceId = serviceId,
                TicketId = ticketId
            };
        }

        public static Workers_On_Ticket ToWorkersFromUpdateDto(this UpdateWorkersRequestDto workersDto, Workers_On_Ticket existingWorkers)
        {
            return new Workers_On_Ticket
            {
                Id = existingWorkers.Id,
                Service_Workers_Quantity = (workersDto.Service_Workers_Quantity <= 0) ? existingWorkers.Service_Workers_Quantity : workersDto.Service_Workers_Quantity,
                ServiceId = existingWorkers.Id,
                TicketId = existingWorkers.TicketId
            };
        }
    }
}