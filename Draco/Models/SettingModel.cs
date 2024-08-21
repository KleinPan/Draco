using System;
using System.Collections.Generic;
using System.Text;

namespace Draco.Models
{
    public class SettingModel
    {
        public UserAccount userInfo { get; set; }
        public SettingModel()
        {

        }
        public int UperLimit { get; set; }
        public int LowerLimit { get; set; }
    }

  public  class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Description { get; set; }
        public string Destination { get; set; }
    }
}
