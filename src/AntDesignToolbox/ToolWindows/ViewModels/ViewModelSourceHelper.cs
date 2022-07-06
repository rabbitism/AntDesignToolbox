using AntDesignToolbox.ToolWindows.ViewModels.EnumOptions;
using Microsoft.VisualStudio.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using BP = AntDesignToolbox.ToolWindows.ViewModels.BooleanPropertyViewModel;
using OCP = System.Collections.ObjectModel.ObservableCollection<AntDesignToolbox.ToolWindows.ViewModels.PropertyItemViewModel>;
using OP = AntDesignToolbox.ToolWindows.ViewModels.OptionsPropertyViewModel;
using SP = AntDesignToolbox.ToolWindows.ViewModels.StringPropertyViewModel;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    internal static class ViewModelSourceHelper
    {
        public static ComponentViewModel ButtonViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Button",
            ControlDisplayName = "Button",
            Moniker = KnownMonikers.Button,
            DefaultMarkup = @"<Button Type=""@ButtonType.Primary"">Primary</Button>",
            Properties = new OCP
            {
                EnumOptionHelper.GetOptionsViewModel<ButtonType>("Type"),
                new SP(){ PropertyName = "Content", DefaultValue = "", Value = ""},
                new BP(){ PropertyName = "Danger"},
                new BP(){ PropertyName = "Disabled"},
                new BP(){ PropertyName = "Block"},
            }
        };
        public static ComponentViewModel TextViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Text",
            ControlDisplayName = "Typography - Text",
            Moniker = KnownMonikers.TextElement,
            DefaultMarkup = @"<Text>Ant Design</Text>",
            Properties = new OCP
            {
                new BP(){ PropertyName = "Code" },
                new BP(){ PropertyName = "Copyable" },
                new BP(){ PropertyName = "Delete" },
                new BP(){ PropertyName = "Editable" },
                new BP(){ PropertyName = "Ellipsis" },
                new BP(){ PropertyName = "Mark" },
                new BP(){ PropertyName = "Keyboard" },
                new BP(){ PropertyName = "Underline" },
                new BP(){ PropertyName = "Strong" },
                new OP(){
                                PropertyName = "Type",
                                DefaultValue="",
                                SelectedValue = "",
                                Options= new ObservableCollection<string>{"", "secondary", "warning", "danger"}
                },
            }
        };
        public static ComponentViewModel TitleViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Title",
            ControlDisplayName = "Typography - Title",
            Moniker = KnownMonikers.TextElement,
            DefaultMarkup = @"<Title>Ant Design</Title>",
            Properties = new OCP
            {
                new BP(){ PropertyName = "Code" },
                new BP(){ PropertyName = "Copyable" },
                new BP(){ PropertyName = "Delete" },
                new BP(){ PropertyName = "Editable" },
                new BP(){ PropertyName = "Ellipsis" },
                new BP(){ PropertyName = "Mark" },
                new BP(){ PropertyName = "Keyboard" },
                new BP(){ PropertyName = "Underline" },
                new BP(){ PropertyName = "Strong" },
                new OP(){
                                PropertyName = "Type",
                                DefaultValue="",
                                SelectedValue = "",
                                Options= new ObservableCollection<string>{"", "secondary", "warning", "danger"}},
                new OP(){
                                PropertyName = "Level",
                                DefaultValue="h1",
                                SelectedValue = "h1",
                                Options= new ObservableCollection<string>{"h1", "h2", "h3", "h4"} }
            }
        };
        public static ComponentViewModel ParagraphViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Paragraph",
            ControlDisplayName = "Typography - Paragraph",
            Moniker = KnownMonikers.TextElement,
            DefaultMarkup = @"<Paragraph>Ant Design</Paragraph>",
            Properties = new OCP
            {
                new BP(){ PropertyName = "Code" },
                new BP(){ PropertyName = "Copyable" },
                new BP(){ PropertyName = "Delete" },
                new BP(){ PropertyName = "Editable" },
                new BP(){ PropertyName = "Ellipsis" },
                new BP(){ PropertyName = "Mark" },
                new BP(){ PropertyName = "Keyboard" },
                new BP(){ PropertyName = "Underline" },
                new BP(){ PropertyName = "Strong" },
                new OP(){
                                PropertyName = "Type",
                                DefaultValue="",
                                SelectedValue = "",
                                Options= new ObservableCollection<string>{"", "secondary", "warning", "danger"}
                },
            }
        };
        public static ComponentViewModel DividerViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Divider",
            ControlDisplayName = "Divider",
            Moniker = KnownMonikers.Splitter,
            DefaultMarkup = @"<Divider />",
            Properties = new OCP()
            {
                new BP(){ PropertyName = "Dashed" },
                new SP(){ PropertyName = "Content", DefaultValue = "", Value = ""},
                new OP(){
                                IgnoreOnDefault=true,
                                PropertyName = "Orientation",
                                DefaultValue="",
                                SelectedValue = "",
                                Options= new ObservableCollection<string>{"", "DirectionVHType.Vertical" } },
            },
        };
        public static ComponentViewModel SpaceViewModel { get; } = new SpaceComponentViewModel()
        {
            ControlName = "Space",
            ControlDisplayName = "Space",
            DefaultMarkup = @"<Space>
    <SpaceItem>
        Space
    </SpaceItem>
    <SpaceItem>
        
    </SpaceItem>
</Space>",
            Moniker = KnownMonikers.VisibleBorders,
            Properties = new OCP()
            {
                new IntegerOrIteratorPropertyViewModel(){ PropertyName = "Children", Count = 2, DefaultCount = 2, ChildrenTagName="SpaceItem", Category = PropertyCategory.Number },
                new BP(){ PropertyName = "Split" },
                new OP(){ PropertyName = "Align", DefaultValue = "", SelectedValue = "",
                    Options = new ObservableCollection<string>{"", "start", "end", "center", "baseline" } },
                new OP(){ PropertyName = "Direction", DefaultValue = "horizontal", SelectedValue=  "horizontal", Options = new ObservableCollection<string>{"horizontal", "vertical"}},
                new OP(){PropertyName = "Size", DefaultValue = "small", SelectedValue = "small", Options = new ObservableCollection<string>{ "small", "middle", "large" } },
                new BP(){PropertyName = "Wrap" }
            }
        };
        public static ComponentViewModel LayoutViewModel { get; } = new LayoutComponentViewModel()
        {
            ControlName = "Layout",
            ControlDisplayName = "Layout",
            DefaultMarkup = @"<Layout>
    <Header>header</Header>
    <Layout>
        <Sider>left sidebar</Sider>
        <Content>main content</Content>
        <Sider>right sidebar</Sider>
    </Layout>
    <Footer>footer</Footer>
</Layout>",
            Moniker = KnownMonikers.LayoutPanel,
            Properties = new OCP()
            {
                new BP(){ PropertyName = "Header" },
                new BP(){ PropertyName = "Sider" },
                new BP(){ PropertyName = "Content" },
                new BP(){ PropertyName = "Footer" },
            }
        };
        public static ComponentViewModel BreadcrumbViewModel { get; } = new BreadcrumbComponentViewModel()
        {
            ControlName = "Breadcrumb",
            ControlDisplayName = "Breadcrumb",
            Moniker = KnownMonikers.Forwardslash,
            DefaultMarkup = @"<Breadcrumb>
	<BreadcrumbItem>Home</BreadcrumbItem>
	<BreadcrumbItem Href="""">Application Center</BreadcrumbItem>
</Breadcrumb>
",
            Properties = new OCP()
            {
                new IntegerPropertyViewModel(){ PropertyName = "Count", DefaultValue = 2, Value = 2 },
                new SP(){ PropertyName = "Separator", DefaultValue = string.Empty, Value = string.Empty }
            }

        };

        public static ComponentViewModel PageHeaderViewModel = new PageHeaderComponentViewModel()
        {
            ControlName = "PageHeader",
            ControlDisplayName = "Page Header",
            Moniker = KnownMonikers.PageHeader,
            DefaultMarkup = @"<PageHeader Class=""site-page-header"" Title=""This is Title"" Subtitle=""This is a subtitle"" />
",
            Properties = new OCP()
            {
                new BP{ PropertyName = "Title" },
                new BP{ PropertyName = "Subtitle" },
                new BP{ PropertyName = "Content" },
                new BP{ PropertyName = "Footer" },
                new BP{ PropertyName = "Tags" },
                new BP{ PropertyName = "Extra" },
                new BP{ PropertyName = "Breadcrumb" },
                new BP{ PropertyName = "Avatar" },
            }
        };
        public static ComponentViewModel IconViewModel { get; } = new IconComponentViewModel()
        {
            ControlName= "Icon",
            ControlDisplayName = "Icon",
            DefaultMarkup = @"<Icon Type=""ant-design"" Theme=""outline""/>",
            Moniker = KnownMonikers.ImageIcon,
        };
        public static ComponentViewModel DropdownButtonViewModel = new ComponentViewModel()
        {
            ControlName = "DropdownButton",
            ControlDisplayName = "DropdownButton",
            DefaultMarkup = @"<DropdownButton>
    <Overlay>
        
    </Overlay>
    <ChildContent>
        
    </ChildContent>
</DropdownButton>"
,
            Moniker = KnownMonikers.ComboBoxItem,
            Properties = new OCP
            {
                EnumOptionHelper.GetOptionsViewModel<ButtonSize>("Size"),
                EnumOptionHelper.GetOptionsViewModel<ButtonType>("Type"),
                new BP(){ PropertyName = "Danger" },
                new BP(){ PropertyName = "Ghost" },
                new BP(){ PropertyName = "Loading" }
            }
        };

        public static ComponentViewModel SampleViewModel = new ComponentViewModel()
        {
            ControlName = "Sample",
            Moniker = KnownMonikers.SamplesFolder,
            DefaultMarkup = @"sample",
            Properties = new OCP()
            {

            },
        };



    }

    internal static class DefaultViewModelSourceHelper
    {
        public static ComponentViewModel Div = new ComponentViewModel()
        {
            ControlName = "<div>",
            Moniker = KnownMonikers.None,
            AlwaysDefault = true,   
            DefaultMarkup = @"<div>

</div>
",
        };
        public static ComponentViewModel If = new ComponentViewModel()
        {
            ControlName = "@if",
            Moniker = KnownMonikers.None,
            AlwaysDefault = true,
            DefaultMarkup = "\n@if( true )\n{\n\n}\n",
        };
        public static ComponentViewModel Foreach = new ComponentViewModel()
        {
            ControlName = "@foreach",
            Moniker = KnownMonikers.None,
            AlwaysDefault = true,
            DefaultMarkup = "\n@foreach(var item in collection)\n{\n\n}\n",
        };
        public static ComponentViewModel CodeBlock = new ComponentViewModel()
        {
            ControlName = "@code",
            Moniker = KnownMonikers.None,
            AlwaysDefault = true,
            DefaultMarkup = "\n@code{\n\n}\n",
        };

    }

    internal static class EnumOptionHelper
    {
        public static StringOptionsViewModel GetOptionsViewModel<T>(string propertyName) where T: System.Enum
        {
            IEnumerable<T> values = Enum.GetValues(typeof(T)).OfType<T>();
            var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            List<StringOptionItemViewModel> list = new List<StringOptionItemViewModel>();
            StringOptionItemViewModel @default = null;
            foreach(var field in fields)
            {
                var attributes = field.CustomAttributes;
                string fieldName = field.Name;
                var stringValue = field.GetCustomAttributes<StringValueAttribute>(false).FirstOrDefault()?.StringValue ?? fieldName;
                var display = field.GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault()?.Name ?? fieldName;
                var isDefault = field.GetCustomAttributes<DefaultAttribute>(false).FirstOrDefault()?.IsDefault ?? false;
                StringOptionItemViewModel vm = new StringOptionItemViewModel(display, stringValue);
                if(@default is null && isDefault)
                {
                    @default = vm;
                }
                list.Add(vm);
            }
            if(@default is null && list.Count > 0)
            {
                @default = list[0];
            }
            return new StringOptionsViewModel()
            {
                PropertyName = propertyName,
                DefaultValue = @default,
                Options = new ObservableCollection<StringOptionItemViewModel>(list),
                SelectedValue = @default,
            };
        }
    }
}
