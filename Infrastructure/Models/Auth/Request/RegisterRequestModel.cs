using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Plans
{
    public class RegisterRequestModel
    {


        public string? name { get; set; } = "";

        public required string email { get; set; }
     
        public required string password { get; set; }

        public required string phoneNumber { get; set; }

    }


}
