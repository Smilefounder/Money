﻿using Money.ViewModels;
using Money.ViewModels.Navigation;
using Money.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Money.Views.Dialogs
{
    public sealed partial class OutcomeCreateGuidePost : ContentDialog
    {
        private readonly INavigator navigator = ServiceProvider.Navigator;

        public OutcomeCreateGuidePost()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            navigator
                .Open(new OutcomeParameter())
                .Show();

            Hide();
        }

        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {
            navigator
                .Open(new SummaryParameter(SummaryViewType.BarGraph))
                .Show();

            Hide();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
