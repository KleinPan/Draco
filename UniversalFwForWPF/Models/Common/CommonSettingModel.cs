using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFwForWPF.Models.Common
{
    public class CommonSettingModel
    {
       
        public SettingUserAccount UserAccount { get; set; } = new SettingUserAccount();

      
        public CommonSettingModel()
        {
        }
    }

    public class SettingUserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Description { get; set; }
        public int Level { get; set; }
    }

   
}
