using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using AntDesignToolbox.Commons;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class IntegerOrIteratorPropertyViewModel : PropertyItemViewModel
    {
        private uint _count;
        public uint Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        public uint DefaultCount { get; set; }

        private bool _iterate;
        public bool Iterate
        {
            get { return _iterate; }
            set { SetProperty(ref _iterate, value); }
        }

        public string ChildrenTagName { get; set; }


        public override ICommand ResetCommand { get; set; }


        public IntegerOrIteratorPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(Reset); 
        }

        private void Reset()
        {
            Count = DefaultCount;
            Iterate = false;
        }

        public override XAttribute ConvertToAttribute()
        {
            throw new NotImplementedException();
        }

        public override XElement ConvertToElement()
        {
            XElement element = new XElement("PlaceHolder");
            if (Iterate)
            {
                element.Add(new XText("\n@foreach (var item in collection)\n{\n"));
                element.Add(new XElement(ChildrenTagName, ChildrenTagName));
                element.Add(new XText("\n}\n"));
                return element;
            }
            else
            {
                for(int i = 0; i< Count; i++)
                {
                    element.Add(new XElement(ChildrenTagName, ChildrenTagName));
                }
                element.EnsureNotEmpty();
                return element;
            }
        }
    }
}
