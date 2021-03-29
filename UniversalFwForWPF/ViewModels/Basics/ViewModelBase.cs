using System;
using System.Collections.Generic;
using System.Text;

using ReactiveUI;

namespace UniversalFwForWPF.ViewModels.Basics
{
    public class ViewModelBase : ReactiveObject
    {
        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();
        public virtual void Init()
        {
            //InitCommand();
            //InitData();
            //InitBindings();

            //InitOthers();
        }

        /// <summary>
        /// 需最后初始化
        /// </summary>
        public virtual void InitBindings()
        {
        }

        public virtual void InitCommand()
        {
        }
        public virtual void InitData()
        {
        }
        public virtual void InitOthers()
        {
        }
        public virtual void InitValidator()
        {
        }

    }
}
