using AutoMapper;
using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Project;
using Promact.TestCaseManagement.DomainModel.Models.User;
using Promact.TestCaseManagement.Repository.ApplicationClass.External;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
using System.Collections.Generic;
using System.Linq;

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
        public async void SyncProjectAndUserDetails(UserInfo userInfo)
        {
            string accessToken = await _iAccessTokenService.GetAccessTokenByRefreshTokenAsync(userInfo.RefreshToken);
            var response = await _iHttpClientService.GetAsync(StringConstants.OAuthUrl, $"{StringConstants.ProjectDetail}/{userInfo.Id}", accessToken);
            var userDetail = Mapper.Map<UserAC>(response);
            Mapper.Map(userDetail, userInfo);
            await _iUserInfoRepository.AddUserInfoAsync(userInfo);
            var projectUserMappingList = new List<ProjectUserMapping>();
            userDetail.Projects.ToList().ForEach(async x =>
            {
                var project = Mapper.Map<Project>(x);
                await _iProjectRepository.AddProjectAsync(project);
                var projectUserMappingListObj = new ProjectUserMapping
                {
                    ProjectId = project.Id,
                    UserId = userInfo.Id,
                    Role = x.Role.Equals(TeamRole.TeamLeader.ToString()) ? TeamRole.TeamLeader : TeamRole.TeamMember
                };
                projectUserMappingList.Add(projectUserMappingListObj);
            });

            _iProjectUserMappingRepository.AddProjectUserMappingList(projectUserMappingList);
        }
    }
}
