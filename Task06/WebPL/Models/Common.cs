using BLL.Interfaces;
using Ioc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WebPL.Models
{
    public static class Common
    {
        public static IUserLogic UserLogic { get; private set; }

        public static IAwardLogic AwardLogic { get; private set; }
        public static IAccountLogic AccountLogic { get; private set; }
        static Common()
        {
            UserLogic = DependencyResolver.UserLogic;
            AwardLogic = DependencyResolver.AwardLogic;
            AccountLogic= DependencyResolver.AccountLogic;
        }
        public static string DateFormat { get { return "yyyy-MM-dd"; } private set { } } 

    }
}