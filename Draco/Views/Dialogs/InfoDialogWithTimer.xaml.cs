﻿using HandyControl.Tools;

using System;
using System.Windows.Controls.Primitives;

namespace Draco.Views.Dialogs
{
    /// <summary>
    /// InfoDialogWithTimer.xaml 的交互逻辑
    /// </summary>
    public partial class InfoDialogWithTimer
    {
        public InfoDialogWithTimer()
        {
            InitializeComponent();

            var animation = AnimationHelper.CreateAnimation(100, 1000 * 10);
            animation.EasingFunction = null;
            animation.Completed += Animation_Completed;
            ProgressBarTimer.BeginAnimation(RangeBase.ValueProperty, animation);
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            ButtonClose.Command.Execute(null);
        }
    }
}