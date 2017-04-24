using AutoMapper;
using Newtonsoft.Json;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.GlobalRepository
{
    public class GlobalRepository : IGlobalRepository
    {
        #region Private Members

        readonly IAccessTokenService _iAccessTokenService;
        readonly IHttpClientService _iHttpClientService;
        readonly IProjectRepository _iProjectRepository;
        readonly IProjectUserMappingRepository _iProjectUserMappingRepository;
        readonly IUserInfoRepository _iUserInfoRepository;
        readonly IMapper _iMapper;
        readonly IStringConstant _iStringConstant;

        #endregion

        #region Constructor

        public GlobalRepository(IAccessTokenService iAccessTokenService, IHttpClientService iHttpClientService, IUserInfoRepository iUserInfoRepository, IProjectRepository iProjectRepository, IProjectUserMappingRepository iProjectUserMappingRepository, IMapper iMapper, IStringConstant iStringConstant)
        {
            _iAccessTokenService = iAccessTokenService;
            _iHttpClientService = iHttpClientService;
            _iUserInfoRepository = iUserInfoRepository;
            _iProjectRepository = iProjectRepository;
            _iProjectUserMappingRepository = iProjectUserMappingRepository;
            _iMapper = iMapper;
            _iStringConstant = iStringConstant;
        }

        #endregion

        public async Task SyncProjectAndUserDetails(UserInfo userInfo)
        {
            string accessToken = await _iAccessTokenService.GetAccessTokenByRefreshTokenAsync(userInfo.RefreshToken);
            var response = await _iHttpClientService.GetAsync(_iStringConstant.OAuthUrl, $"{_iStringConstant.ProjectDetail}/{userInfo.Id}", accessToken);
            var userDetail = JsonConvert.DeserializeObject<UserDetailWithProject>(response);
            _iMapper.Map(userDetail.UserAc, userInfo);
            await _iUserInfoRepository.AddUserInfoAsync(userInfo);
            var projectUserMappingList = new List<ProjectUserMapping>();
            var projectList = userDetail.ListOfProject;
            foreach (var projectAC in projectList)
            {
                var project = _iMapper.Map<Project>(projectAC);
                await _iProjectRepository.AddProjectAsync(project);
                var projectUserMappingListObj = new ProjectUserMapping
                {
                    ProjectId = project.Id,
                    UserId = userInfo.Id,
                    Role = projectAC.TeamLeaderId.Equals(userInfo.Id) ? _iStringConstant.TeamLeader : _iStringConstant.TeamMember
                };
                projectUserMappingList.Add(projectUserMappingListObj);
            };

            await _iProjectUserMappingRepository.AddProjectUserMappingList(projectUserMappingList);
        }
    }
}
