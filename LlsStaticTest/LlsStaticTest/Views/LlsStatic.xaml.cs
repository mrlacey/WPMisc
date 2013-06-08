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

    public partial class LlsStatic : PhoneApplicationPage
    {
        public LlsStatic()
        {
            InitializeComponent();
            Debug.WriteLine("LlsStatic constructor");
        }

        ~LlsStatic()
        {
            Debug.WriteLine("LlsStatic destructor");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Debug.WriteLine("LlsStatic OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Debug.WriteLine("LlsStatic OnNavigatedFrom");

            // The following will remove the problem and allow the page to be collected
            //if (e.NavigationMode == NavigationMode.Back)
            //{
            //    this.DataContext = null;
            //}
        }
    }
}