using AutoMapper;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models;
using Infrastructure.Models.Plans;
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
    public class SeedsUsers
    {

        public List<UserApp>  Db { get=> db;}

        private static List<UserApp> db=new List<UserApp>() {
        
            new UserApp{ id="12345",name="Test User",email="test@gmail.com",password="Test@123",phoneNumber="771211417",active=true },
            new UserApp{ id="1345678",name="User",email="user@gmail.com",password="Test@2025",phoneNumber="781211417",active=true },
            new UserApp{ id="1345678",name="Azdeen",email="Azdeenedghg@gmail.com",password="Azdeen2024$$$",phoneNumber="781211417",active=true },
        
        };

        private readonly IMapper _mapper;

        //public SeedsUsers(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}
        public async Task<UserModel?> loginAsync(LoginRequestModel model)
        {

            if (db != null )
            {
                var user=db.FirstOrDefault(x => x.email == model.email && x.password == model.password);
               if(user != null) 
                 return user;
            }
      
            return null;

        }
        public async Task<bool> createUserAsync(UserApp model) {

            if (db != null && db.FirstOrDefault(x => x.email == model.email) == null)
            {
                model.id = Guid.NewGuid().ToString();
                model.active = true;
                //var user = _mapper.Map<UserApp>(model);
                db.Add(model);
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<IEnumerable<UserModel>?> getAllUsersAsync()
        {
            var users = (db.Count>0)? _mapper.Map<IEnumerable<UserModel>>(db): new List<UserModel>();
            return users;
        }

        public async Task<UserModel?> getUserByIdAsync(string id)
        {
           var user =  db.FirstOrDefault(x => x.id == id);
           if (user == null)
                return  _mapper.Map<UserModel>(user);

            return null;
        }


    }
}
