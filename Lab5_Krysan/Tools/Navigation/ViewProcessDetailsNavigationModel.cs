using Lab5_Krysan.Views;
using System;


namespace Lab5_Krysan.Tools.Navigation
{
    internal class ViewProcessDetailsNavigationModel : BaseNavigationModel
    {
        public ViewProcessDetailsNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
            {
                switch (viewType)
                {
                    case ViewType.ProcessDetails:
                        ViewsDictionary.Add(viewType, new ProcessDetailsView());
                        break;
                    case ViewType.Main:
                        ViewsDictionary.Add(viewType, new MainView());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
                }
            }
            else
            {
                switch (viewType)
                {
                    case ViewType.ProcessDetails:
                        ViewsDictionary[viewType] = new ProcessDetailsView();
                        break;
                    case ViewType.Main:
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
                }
            }
        }

    }
}
