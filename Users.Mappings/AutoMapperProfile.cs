//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Vehicles.Contracts.Locations;
//using Vehicles.Contracts.Vehicles;
//using Vehicles.Data.Entities;
//using Vehicles.Models.Locations;
//using Vehicles.Models.Vehicles;

//namespace Vehicles.Mappings
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            CreateMap<Vehicle, VehicleModel>().ReverseMap();
//            CreateMap<VehicleModel, VehicleContract>().ReverseMap();
//            CreateMap<CreateVehicleContract, CreateVehicleModel>();
//            CreateMap<Vehicle, CreateVehicleModel>().ReverseMap();

//            CreateMap<Location, LocationModel>().ReverseMap();
//            CreateMap<LocationModel, LocationContract>().ReverseMap();
//            CreateMap<CreateLocationModel, CreateLocationContract>().ReverseMap();
//            CreateMap<Location, CreateLocationModel>().ReverseMap();
//        }
//    }
//}