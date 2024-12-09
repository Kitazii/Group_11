using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Models;
using DtosBusinessType = api.Dtos.Business.Enum.BusinessType;

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
                PhoneNumber = businessModel.PhoneNumber,
                Street = businessModel.Street,
                City = businessModel.City,
                Postcode = businessModel.Postcode,
                BusinessType = (DtosBusinessType)businessModel.BusinessType,
                BusinessTypeValue = businessModel.BusinessType.HasValue 
            ? Enum.GetName(typeof(BusinessType), businessModel.BusinessType.Value) 
            : null
            };
        }

        public static Business ToBusinessFromCreateDTO(this CreateBusinessRequestDto businessDto)
        {
            return new Business
            {
                Name = businessDto.Name,
                Email = businessDto.Email,
                PhoneNumber = businessDto.PhoneNumber,
                Street = businessDto.Street,
                City = businessDto.City,
                Postcode = businessDto.Postcode,
                BusinessType = (BusinessType)businessDto.BusinessType,
                BusinessTypeValue = businessDto.BusinessType.HasValue 
            ? Enum.GetName(typeof(BusinessType), businessDto.BusinessType.Value) 
            : null
            };
        }
    }
}