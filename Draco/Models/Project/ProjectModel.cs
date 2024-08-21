using System;
using System.Collections.Generic;
using System.Text;

namespace Draco.Models.Project
{

    public class ProjectModelBase
    {
        public string Name { get; set; }
     
    }

    public class ProjectModel: ProjectModelBase
    {
        
        public DateTime CreateTime { get; set; }
    }
}
