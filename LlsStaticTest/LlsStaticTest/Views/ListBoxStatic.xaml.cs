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

    public partial class ListBoxStatic : PhoneApplicationPage
    {
        public ListBoxStatic()
        {
            InitializeComponent();
            Debug.WriteLine("ListBoxStatic constructor");
        }

        ~ListBoxStatic()
        {
            Debug.WriteLine("ListBoxStatic destructor");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Debug.WriteLine("ListBoxStatic OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Debug.WriteLine("ListBoxStatic OnNavigatedFrom");
        }
    }
}