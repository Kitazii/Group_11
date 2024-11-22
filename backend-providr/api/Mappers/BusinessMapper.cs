using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Models;

namespace api.Mappers
{
    public static class BusinessMapper
    {
        public static BusinessDto ToBusinessDto(this Business businessModel)
        {
            return new BusinessDto
            {
                Id = businessModel.Id,
                Name = businessModel.Name,
                Email = businessModel.Email,
                TelephoneNumber = businessModel.TelephoneNumber,
                Street = businessModel.Street,
                City = businessModel.City,
                Postcode = businessModel.Postcode
            };
        }

        public static Business ToBusinessFromCreateDTO(this CreateBusinessRequestDto businessDto)
        {
            return new Business
            {
                Name = businessDto.Name,
                Email = businessDto.Email,
                TelephoneNumber = businessDto.TelephoneNumber,
                Street = businessDto.Street,
                City = businessDto.City,
                Postcode = businessDto.Postcode
            };
        }
    }
}