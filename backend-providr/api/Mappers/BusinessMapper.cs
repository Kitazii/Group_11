using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Models;
using DtosBusinessType = api.Dtos.Business.Enum.BusinessType;

namespace api.Mappers
{
    //Used to map Data Transfer Objects to our business logic models
    //Ensuring a smooth transition, when throwing objects to our end points
    public static class BusinessMapper
    {
        #pragma warning disable CS8629 // Nullable value type may be null.
        #pragma warning disable CS8601
        public static BusinessDto ToBusinessDto(this Business businessModel)
        {
            return new BusinessDto
            {
                Id = businessModel.Id,
                Name = businessModel.Name,
                Username = businessModel.UserName,
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
                UserName = businessDto.Username,
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

        public static Business ToBusinessFromUpdateDto(this UpdateBusinessRequestDto businessDto, Business existingBusiness)
        {
            return new Business
            {
                UserName = string.IsNullOrWhiteSpace(businessDto.Username) ? existingBusiness.UserName : businessDto.Username,
                Name = string.IsNullOrWhiteSpace(businessDto.Name) ? existingBusiness.Name : businessDto.Name,
                Email = string.IsNullOrWhiteSpace(businessDto.Email) ? existingBusiness.Email : businessDto.Email,
                PhoneNumber = string.IsNullOrWhiteSpace(businessDto.PhoneNumber) ? existingBusiness.PhoneNumber : businessDto.PhoneNumber,
                Street = string.IsNullOrWhiteSpace(businessDto.Street) ? existingBusiness.Street : businessDto.Street,
                City = string.IsNullOrWhiteSpace(businessDto.City) ? existingBusiness.City : businessDto.City,
                Postcode = string.IsNullOrWhiteSpace(businessDto.Postcode) ? existingBusiness.Postcode : businessDto.Postcode,
                BusinessType = businessDto.BusinessType.HasValue ? (BusinessType)businessDto.BusinessType.Value : existingBusiness.BusinessType,
                BusinessTypeValue = businessDto.BusinessType.HasValue
                    ? Enum.GetName(typeof(BusinessType), businessDto.BusinessType.Value)
                    : existingBusiness.BusinessTypeValue
            };
        }
        #pragma warning restore CS8629 // Nullable value type may be null.
        #pragma warning restore CS8601
    }
}