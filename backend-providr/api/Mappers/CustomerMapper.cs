using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Models;
using DtosCustomerType = api.Dtos.Customer.Enum.CustomerType;

namespace api.Mappers
{
    //Used to map Data Transfer Objects to our business logic models
    //Ensuring a smooth transition, when throwing objects to our end points
    public static class CustomerMapper
    {
        #pragma warning disable CS8629 // Nullable value type may be null.
        #pragma warning disable CS8601
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Forename = customerModel.Forename,
                Surname = customerModel.Surname,
                Email = customerModel.Email,
                Username = customerModel.UserName,
                PhoneNumber = customerModel.PhoneNumber,
                Street = customerModel.Street,
                City = customerModel.City,
                Postcode = customerModel.Postcode,
                CustomerType = (DtosCustomerType)customerModel.CustomerType,
                CustomerTypeValue = customerModel.CustomerType.HasValue 
            ? Enum.GetName(typeof(CustomerType), customerModel.CustomerType.Value) 
            : null
            };
        }

        public static Customer ToCustomerFromCreateDTO(this CreateCustomerRequestDto customerDto)
        {
            return new Customer
            {
                UserName = customerDto.Username,
                Forename = customerDto.Forename,
                Surname = customerDto.Forename,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                Street = customerDto.Street,
                City = customerDto.City,
                Postcode = customerDto.Postcode,
                CustomerType = (CustomerType)customerDto.CustomerType,
                CustomerTypeValue = customerDto.CustomerType.HasValue 
            ? Enum.GetName(typeof(CustomerType), customerDto.CustomerType.Value) 
            : null
            };
        }

        public static Customer ToCustomerFromUpdateDto(this UpdateCustomerRequestDto customerDto, Customer existingCustomer)
        {
            return new Customer
            {
                UserName = string.IsNullOrWhiteSpace(customerDto.Username) ? existingCustomer.UserName : customerDto.Username,
                Forename = string.IsNullOrWhiteSpace(customerDto.Forename) ? existingCustomer.Forename : customerDto.Forename,
                Surname = string.IsNullOrWhiteSpace(customerDto.Surname) ? existingCustomer.Surname : customerDto.Surname,
                Email = string.IsNullOrWhiteSpace(customerDto.Email) ? existingCustomer.Email : customerDto.Email,
                PhoneNumber = string.IsNullOrWhiteSpace(customerDto.PhoneNumber) ? existingCustomer.PhoneNumber : customerDto.PhoneNumber,
                Street = string.IsNullOrWhiteSpace(customerDto.Street) ? existingCustomer.Street : customerDto.Street,
                City = string.IsNullOrWhiteSpace(customerDto.City) ? existingCustomer.City : customerDto.City,
                Postcode = string.IsNullOrWhiteSpace(customerDto.Postcode) ? existingCustomer.Postcode : customerDto.Postcode,
                CustomerType = customerDto.CustomerType.HasValue ? (CustomerType)customerDto.CustomerType.Value : existingCustomer.CustomerType,
                CustomerTypeValue = customerDto.CustomerType.HasValue
                    ? Enum.GetName(typeof(CustomerType), customerDto.CustomerType.Value)
                    : existingCustomer.CustomerTypeValue
            };
        }
        #pragma warning restore CS8629 // Nullable value type may be null.
        #pragma warning restore CS8601
    }
}