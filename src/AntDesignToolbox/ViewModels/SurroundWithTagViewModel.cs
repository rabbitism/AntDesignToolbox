using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;


namespace AntDesignToolbox.ViewModels
{
    public class SurroundWithTagViewModel: BindableBase
    {
        private ObservableCollection<TagItem> _tags;
        public ObservableCollection<TagItem> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }


        public SurroundWithTagViewModel()
        {
            Tags = new ObservableCollection<TagItem>(InitializeTags());

        }

        private List<TagItem> InitializeTags()
        {
            var tags = new List<TagItem>();
            tags.Add(new TagItem { TagName = "div", OpenTag = "<div>", CloseTag = "</div>" });
            tags.Add(new TagItem { TagName = "span", OpenTag = "<span>", CloseTag = "</span>" });
            return tags;
        }
    }

    public class TagItem: BindableBase
    {
        private string _tagName;
        public string TagName
        {
            get { return _tagName; }
            set { SetProperty(ref _tagName, value); }
        }

        public string OpenTag { get; set; }
        public string CloseTag { get; set; }

    }
}
