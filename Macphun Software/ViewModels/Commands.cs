using System.Windows.Input;

namespace Photoviewer.ViewModels
{
    partial class ViewModel
    {
        /// <summary>
        /// Перейти до фотоколекції 
        /// </summary>
        public ICommand ReturnToMainView => new RelayCommand(CloseSecondView);

        /// <summary>
        /// Відкрити фото 
        /// </summary>
        public ICommand OpenPhotoView => new RelayCommand(OpenSecondView);

        /// <summary>
        /// Наступне фото
        /// </summary>
        public ICommand ViewNextPhoto => new RelayCommand(SelectNext);

        /// <summary>
        /// Попереднє фото
        /// </summary>
        public ICommand ViewPreviousPhoto => new RelayCommand(SelectPrevious);

        /// <summary>
        /// Накладання ефекту на зобрження
        /// </summary>
        public ICommand GaussianBlurEffect => new RelayCommand(SetGaussianBlurEffect);        
    }
}
