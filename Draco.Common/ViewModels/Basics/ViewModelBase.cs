using CommunityToolkit.Mvvm.ComponentModel;

namespace Draco.Common.ViewModels.Basics
{
    public class ViewModelBase : ObservableObject
    {

        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();
        public virtual void Init()
        { 
            //InitData();
           
            //InitOthers();
        }

       
        
        public virtual void InitData()
        {
        }
       
        public virtual void InitValidator()
        {
        }

    }
}
