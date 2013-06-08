using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace LlsStaticTest.Views
{
    using System.Diagnostics;

    using LlsStaticTest.ViewModel;

    public partial class ListBoxNonStatic : PhoneApplicationPage
    {
        public ListBoxNonStatic()
        {
            InitializeComponent();

            this.DataContext = new NonStaticNames();

            Debug.WriteLine("ListBoxNonStatic constructor");
        }

        ~ListBoxNonStatic()
        {
            Debug.WriteLine("ListBoxNonStatic destructor");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Debug.WriteLine("ListBoxNonStatic OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Debug.WriteLine("ListBoxNonStatic OnNavigatedFrom");
        }
    }
}