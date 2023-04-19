﻿using AutoMapper;
using HRMS.Models;
using HRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Helpers
{
    public class AutoMappperProfiles : Profile
    {
        public AutoMappperProfiles(HRMSDbContext context)
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName,src => src.MapFrom(sc => sc.Department.Name))
                .ForMember(dest => dest.DepartmentId, src => src.MapFrom(sc => sc.Department.Id));

            //CreateMap<Employee, EmployeeDto>(

            //).AfterMap((s,d) =>
            //{
            //    d.DepartmentId=s.Department.Id

                
            //}
            //    );
            
        }
    }
}
