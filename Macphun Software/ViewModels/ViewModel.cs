using Photoviewer.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Photoviewer.ViewModels
{
    partial class ViewModel : ObservableObject
    {
        public ViewModel() => imagesCollection = new ObservableCollection<PhotoviewerImage>();
         

        #region Колекція зображень        

        private ObservableCollection<PhotoviewerImage> imagesCollection;

        public ObservableCollection<PhotoviewerImage> ImagesCollection
        {
            get { return imagesCollection; }
            set
            {
                imagesCollection = value;
                OnPropertyChanged(nameof(ImagesCollection));
            }
        }       

        void AddImageToCollection(string imageUri)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
            () =>
            {
                PhotoviewerImage photoviewerImage = new PhotoviewerImage(imageUri);
                if (photoviewerImage.IsSupportedByViewer)
                    ImagesCollection.Add(photoviewerImage);
            }));

            if (imagesCollection.Count > 0)
                Display = string.Empty;
        }

        #endregion

        #region Зображення другого вигляду        

        int selectedPhotoviewerImageIndex;

        public int SelectedPhotoviewerImageIndex
        {
            get { return selectedPhotoviewerImageIndex; }
            set
            {
                selectedPhotoviewerImageIndex = value;
                OnPropertyChanged(nameof(SelectedPhotoviewerImageIndex));
            }
        }        

        void SelectNext(object obj) => GetImage(selectedPhotoviewerImageIndex + 1);

        void GetImage(int id)
        {
            try
            {                
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    () =>
                    {
                        // завантаження повнорозмірного зображення
                        var PhotoImageItemToUpdate = imagesCollection[id];
                        PhotoImageItemToUpdate.GetFullBitmap();
                        PhotoToView = PhotoImageItemToUpdate.FullBitmap;                        

                        // заміна його в колекції 
                        ImagesCollection.Insert(id, PhotoImageItemToUpdate);
                        ImagesCollection.RemoveAt(id + 1);
                        selectedPhotoviewerImageIndex = id;
                    }));                               
            }
            catch (Exception)
            {                
                // відсутній елемент в колекції..
            }            
        }

        void SelectPrevious(object obj) => GetImage(selectedPhotoviewerImageIndex - 1);        

        BitmapImage selectedImage;
                
        public BitmapImage PhotoToView
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                OnPropertyChanged(nameof(PhotoToView));
            }
        }

        #endregion

        #region Для відображення інформації        

        string display = "Drop Your Photo Here";

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        #endregion

        public Dispatcher Dispatcher { get; set; }
    }
}
