namespace Lab5_Krysan.Tools.Navigation
{
    internal enum ViewType
    {
        ProcessDetails,
        Main
    }


    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
