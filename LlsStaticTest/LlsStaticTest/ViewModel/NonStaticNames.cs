namespace LlsStaticTest.ViewModel
{
    using System.Collections.ObjectModel;

    public class NonStaticNames : ObservableCollection<string>
    {
        public NonStaticNames()
        {
            Add("Andy");
            Add("Bob");
            Add("Claire");
            Add("Danny");
            Add("Erica");
            Add("Freddy");
            Add("Gavin");
            Add("Holly");
            Add("Iris");
        }
    }
}
