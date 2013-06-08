using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LlsStaticTest.Views
{
    using System.Diagnostics;

    using LlsStaticTest.ViewModel;

    public partial class LlsNonStatic : PhoneApplicationPage
    {
        public LlsNonStatic()
        {
            InitializeComponent();

            this.DataContext = new NonStaticNames();

            Debug.WriteLine("LlsNonStatic constructor");
        }

        ~LlsNonStatic()
        {
            Debug.WriteLine("LlsNonStatic destructor");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Debug.WriteLine("LlsNonStatic OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Debug.WriteLine("LlsNonStatic OnNavigatedFrom");
        }
    }
}