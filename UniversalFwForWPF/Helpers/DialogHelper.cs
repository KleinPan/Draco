using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.ViewModels.Dialogs;
using UniversalFwForWPF.Views.Dialogs;

namespace UniversalFwForWPF.Helpers
{
    public class DialogHelper
    {
        public static DialogHelper Instance = new Lazy<DialogHelper>(() => new DialogHelper()).Value;

        public async Task<string> ShowInteractiveDialog(string header)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMBase()
            {
                Message = header,
            };
            var DialogResult1 = await myDialog.GetResultAsync<string>();

            return await Task.FromResult(DialogResult1);
        }
        public async Task<string> ShowInteractiveDialog(string header, string text)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMBase()
            {
                Message = header,
                Result = text,
            };
            var DialogResult1 = await myDialog.GetResultAsync<string>();

            return await Task.FromResult(DialogResult1);
        }



       

      
        public async Task<DialogResult> ShowTimerDialog(string header)
        {
            var myDialog = Dialog.Show<InfoDialogWithTimer>();

            myDialog.DataContext = new DialogVMBase()
            {
                Header = header,
            };

            var DialogResult1 = await myDialog.GetResultAsync<DialogResult>();

            return await Task.FromResult(DialogResult1);
        }

        public async Task<Dialog> ShowWaiterDialog(string header)
        {
            var myDialog = Dialog.Show<WaiterDialog>();

            //WaiterDialogVM waiterDialogVM = new WaiterDialogVM()
            //{
            //    Header = header,
            //};
            //myDialog.DataContext = waiterDialogVM;
            myDialog.DataContext = new DialogVMBase()
            {
                Header = header,
            };

            //var DialogResult1 = await myDialog.GetResultAsync<string>();
            // var vm =   myDialog.GetViewModel<WaiterDialogVM>();
            return await Task.FromResult(myDialog);
        }
    }
}
