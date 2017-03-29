using AutoMapper;
using Newtonsoft.Json;
using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.External;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
using System.Collections.Generic;
using System.Linq;
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

        #endregion

        #region Constructor

        public GlobalRepository(IAccessTokenService iAccessTokenService, IHttpClientService iHttpClientService, IUserInfoRepository iUserInfoRepository, IProjectRepository iProjectRepository, IProjectUserMappingRepository iProjectUserMappingRepository)
        {
            _iAccessTokenService = iAccessTokenService;
            _iHttpClientService = iHttpClientService;
            _iUserInfoRepository = iUserInfoRepository;
            _iProjectRepository = iProjectRepository;
            _iProjectUserMappingRepository = iProjectUserMappingRepository;
        }

        #endregion

        /// <summary>
        /// Method to sync project and user details
        /// </summary>
        /// <param name="userInfo">User info object</param>
        public async Task SyncProjectAndUserDetails(UserInfo userInfo)
        {
            string accessToken = await _iAccessTokenService.GetAccessTokenByRefreshTokenAsync(userInfo.RefreshToken);
            var response = await _iHttpClientService.GetAsync(StringConstants.OAuthUrl, $"{StringConstants.ProjectDetail}/{userInfo.Id}", accessToken);
            var userDetail = JsonConvert.DeserializeObject<UserDetailWithProject>(response);
            Mapper.Map(userDetail.UserAc, userInfo);
            await _iUserInfoRepository.AddUserInfoAsync(userInfo);
            var projectUserMappingList = new List<ProjectUserMapping>();
            var projectList = userDetail.ListOfProject.ToList();
            foreach (var projectAC in projectList)
            {
                var project = Mapper.Map<Project>(projectAC);
                await _iProjectRepository.AddProjectAsync(project);
                var projectUserMappingListObj = new ProjectUserMapping
                {
                    ProjectId = project.Id,
                    UserId = userInfo.Id,
                    Role = projectAC.TeamLeaderId.Equals(userInfo.Id) ? TeamRole.TeamLeader : TeamRole.TeamMember
                };
                projectUserMappingList.Add(projectUserMappingListObj);
            };

            await _iProjectUserMappingRepository.AddProjectUserMappingList(projectUserMappingList);
        }
    }
}
