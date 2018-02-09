using System;
using System.Windows.Media.Imaging;

namespace Photoviewer.Models
{
    public class PhotoviewerImage
    {
        private PhotoviewerImage() { }

        public PhotoviewerImage(string imageUri)
        {
            try
            {
                //Bitmap = new BitmapImage(new Uri(imageUri));

                Bitmap = new BitmapImage();
                Bitmap.BeginInit();
                Bitmap.UriSource = new Uri(imageUri);
                Bitmap.DecodePixelWidth = 250;
                Bitmap.EndInit();

                IsSupportedByViewer = true;
            }
            catch (Exception)
            {                
                //тип зображень не підтримується
            }           
        }

        /// <summary>
        /// Чи підтримуються дані типи зображень  
        /// </summary>
        public bool IsSupportedByViewer { get; private set; }

        /// <summary>
        /// Зменшена картинка для колекції
        /// </summary>
        public BitmapImage Bitmap { get; }

        /// <summary>
        /// Картинка в повному розмірі
        /// </summary>
        public BitmapImage FullBitmap { get; private set; }  
        
        /// <summary>
        /// Отримата зображення повнорозмірне зображення
        /// </summary>
        public void GetFullBitmap()
        {
            FullBitmap = FullBitmap?? new BitmapImage(new Uri(Bitmap.UriSource.AbsoluteUri));
        }
    }
}
