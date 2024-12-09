using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Settings
{



    public class ApplicationModeService
    {
        public static ApplicationMode CurrentMode { get; private set; }

        public ApplicationMode getCurrentMode { get => CurrentMode; }

        private static ApplicationModeService _instance;

        public static ApplicationModeService getInstance(ApplicationMode mode)
        {

            if (_instance == null)
            {
                CurrentMode = mode;
                _instance = new ApplicationModeService();
            }

            return _instance;
        }
    }
}
