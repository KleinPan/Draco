using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFwForWPF.Models.Plugin
{
    /// <summary> 项目无关 </summary>
    public class PluginSettingModel
    {
        /// <summary> 所有要加载的插件列表 </summary>
        public List<PluginInfoModel> AllLoadPlugins { get; set; } = new List<PluginInfoModel>();

        public PluginSettingModel()
        {
        }
    }
}
