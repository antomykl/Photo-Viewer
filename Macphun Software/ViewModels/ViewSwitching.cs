namespace Photoviewer.ViewModels
{
    partial class ViewModel
    {
        void CloseSecondView(object obj)
        {
            IsSecondViewVisible = false;
            IsMainViewVisible = true;
        }

        void OpenSecondView(object obj)
        {
            GetImage(SelectedPhotoviewerImageIndex);

            IsSecondViewVisible = true;
            IsMainViewVisible = false;
        }

        bool isSecondViewVisible;

        public bool IsSecondViewVisible
        {
            get { return isSecondViewVisible; }
            set
            {
                isSecondViewVisible = value;
                OnPropertyChanged(nameof(IsSecondViewVisible));
            }
        }

        bool isMainViewVisible = true;

        public bool IsMainViewVisible
        {
            get { return isMainViewVisible; }
            set
            {
                isMainViewVisible = value;
                OnPropertyChanged(nameof(IsMainViewVisible));
            }
        }
    }
}
