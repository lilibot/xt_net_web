using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Interfaces;
using BLL;
using System.Configuration;

namespace Ioc
{
    public static class DependencyResolver
    {
        public static IUserDao UserDao { get; private set; }

        public static IUserLogic UserLogic { get; private set; }

        public static IAwardDao AwardDao { get; set; }

        public static IAwardLogic AwardLogic { get; set; }

        static DependencyResolver()
        {
            var DALappSetting = ReadSetting("DAL");
            if (DALappSetting == "File")
            {
                UserDao = new FileUserDao();
                AwardDao = new FileAwardDao();
            }
            else
            {
                UserDao = new MemoryUserDao();
                AwardDao = new MemoryAwardDao();
            }

            UserLogic = new UserLogic(UserDao);
            AwardLogic = new AwardLogic(AwardDao);
        }

        private static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key]??"Not found";
            }
            catch (ConfigurationErrorsException)
            {
                return "Not found";
            }
        }

    }
}
