using AutoMapper;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsProfile
    {
        private readonly IMapper _mapper;
        private readonly SeedsUsers seedsUsers;
        private readonly List<UserApp> userDb;
        

        public SeedsProfile(IMapper mapper, SeedsUsers seedsUsers)
        {
            _mapper = mapper;
            this.seedsUsers = seedsUsers;
            userDb=seedsUsers.Db;
        }

        public async Task<ProfileResponseModel> getProfileAsync()
        {

            
            return new ProfileResponseModel();

        }


    }
}
