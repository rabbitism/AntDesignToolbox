using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AntDesignToolbox.ToolWindows.ViewModels;

namespace AntDesignToolbox.Commons
{
    public static class ViewModelHelper
    {
        public static T GetProperty<T>( this ObservableCollection<PropertyItemViewModel> collection, string name) where T:PropertyItemViewModel
        {
            var property = collection.OfType<T>().FirstOrDefault(a => a.PropertyName == name);
            return property;
        }
    }
}
