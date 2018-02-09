using System.Windows.Media.Effects;

namespace Photoviewer.ViewModels
{
    partial class ViewModel
    {
        void SetGaussianBlurEffect(object obj)
        {
            if (set) 
            {
                BlurEffect = null;
                set = false;
            }
            else
            {
                BlurEffect = new BlurEffect { KernelType = KernelType.Gaussian };
                set = true;
            }            
        }

        bool set;

        BlurEffect blurEffect;

        public BlurEffect BlurEffect
        {
            get { return blurEffect; }
            set
            {
                blurEffect = value;
                OnPropertyChanged(nameof(BlurEffect));
            }
        }        
    }
}
