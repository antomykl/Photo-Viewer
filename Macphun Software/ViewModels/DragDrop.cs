using System.Linq;
using GongSolutions.Wpf.DragDrop;
using System.Windows;

namespace Photoviewer.ViewModels
{
    partial class ViewModel : IDropTarget
    {
        public void Drop(IDropInfo dropInfo)
        {
            var dragFileList = ((DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            foreach (var item in dragFileList)            
                AddImageToCollection(item.ToString());                        
        }

        public void DragOver(IDropInfo dropInfo) => dropInfo.Effects = DragDropEffects.Copy;                
    }
}
