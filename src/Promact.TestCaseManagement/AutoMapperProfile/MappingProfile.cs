using AutoMapper;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass;
using Promact.TestCaseManagement.Repository.ApplicationClass.Module;
using Promact.TestCaseManagement.Repository.ApplicationClass.Scenario;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;

namespace Promact.TestCaseManagement.Web.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ScenarioAC, Scenario>().ReverseMap();
            CreateMap<ModuleAC, Module>().ReverseMap();
            CreateMap<TestCaseAC, TestCase>().ReverseMap();
            CreateMap<TestCaseInputAc, TestCaseInput>().ReverseMap();
            CreateMap<TestCaseStepsAC, TestCaseSteps>().ReverseMap();
            CreateMap<UserInfo, UserAC>().ReverseMap();
            CreateMap<Project, ProjectAC>().ReverseMap();
        }
    }
}