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

        public override bool IsAttribute { get; set; } = false;

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

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            if (Iterate)
            {
                yield return new XText("\n@foreach (var item in collection)\n{\n");
                yield return new XElement(ChildrenTagName, ChildrenTagName);
                yield return new XText("\n}\n");
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return new XElement(ChildrenTagName, ChildrenTagName);
                }
            }
        }
    }
}
