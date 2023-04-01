namespace AD2_WEB_APP.Helpers;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Models.Users;
using AD2_WEB_APP.Models.Customer;
using AD2_WEB_APP.Models.Address;
using AD2_WEB_APP.Models.Configuration;
using AD2_WEB_APP.Models.Category;
using AD2_WEB_APP.Models.ComputerModel;
using AD2_WEB_APP.Models.DefaultConfiguration;
using AD2_WEB_APP.Models.Item;
using AD2_WEB_APP.Models.Order;
using AD2_WEB_APP.Models.OrderItem;
using AD2_WEB_APP.Models.Payment;
using AD2_WEB_APP.Models.Series;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));

        // CreateRequest -> Customer
        CreateMap<CreateRequestCustomer, Customer>();
        CreateMap<CreateCustomer, Customer>();
        CreateMap<CreateRequestAddress, Address>();
        CreateMap<CreateRequestConfiguration, Configuration>();
        CreateMap<CreateRequestCategory, Category>();
        CreateMap<CreateRequestComputerModel, ComputerModel>();
        CreateMap<CreateRequestDefaultConfiguration, DefaultConfiguration>();
        CreateMap<CreateRequestItem, Item>();
        CreateMap<CreateRequestOrder, Order>();
        CreateMap<CreateRequestOrderItem, OrderItem>();
        CreateMap<CreateRequestPayment, Payment>();
        CreateMap<CreateRequestSeries, Series>();
    }
}