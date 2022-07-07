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
                new SP(){ PropertyName = "Content", DefaultValue = "", Value = "", IsAttribute = false},
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
                EnumOptionHelper.GetOptionsViewModel<TypographyType>("Type", true),
                
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
                EnumOptionHelper.GetOptionsViewModel<TypographyType>("Type", true),
                EnumOptionHelper.GetOptionsViewModel<TitleLevel>("Level"),
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
                EnumOptionHelper.GetOptionsViewModel<TypographyType>("Type", true),
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
        public static ComponentViewModel SpaceViewModel { get; } = new ComponentViewModel()
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
                EnumOptionHelper.GetOptionsViewModel<Direction>("Direction"),
                EnumOptionHelper.GetOptionsViewModel<Size>("Size"),
                new BP(){PropertyName = "Wrap" }
            }
        };
        public static ComponentViewModel LayoutViewModel { get; } = new ComponentViewModel()
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
</Layout>"
,
            Moniker = KnownMonikers.LayoutPanel,
            Properties = new OCP
            {
                new ContainsElementPropertyViewModel(){ PropertyName = "Header", PropertyDisplayName = "Header" },
                new ContainsElementPropertyViewModel(){ PropertyName = "Sider", PropertyDisplayName = "Header" },
                new ContainsElementPropertyViewModel(){ PropertyName = "Content", PropertyDisplayName = "Content" },
                new ContainsElementPropertyViewModel(){ PropertyName = "Footer", PropertyDisplayName = "Footer" },
            }
        };
        public static ComponentViewModel BreadcrumbViewModel { get; } = new ComponentViewModel()
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
                new IntegerOrIteratorPropertyViewModel(){ PropertyName = "Count", DefaultCount = 2, Count=2, ChildrenTagName = "BreadcrumbItem" },
                new SP(){ PropertyName = "Separator", DefaultValue = string.Empty, Value = string.Empty }
            }
        };
        public static ComponentViewModel PageHeaderViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "PageHeader",
            ControlDisplayName = "Page Header",
            Moniker = KnownMonikers.PageHeader,
            DefaultMarkup = @"<PageHeader Class=""site-page-header"" Title=""This is Title"" Subtitle=""This is a subtitle"" />
",
            Properties = new OCP()
            {
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Title", PropertyName="PageHeaderTitle", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Subtitle",PropertyName="PageHeaderSubtitle", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Content",PropertyName="PageHeaderContent", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Footer",PropertyName="PageHeaderFooter", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Tags",PropertyName="PageHeaderTags", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Extra",PropertyName="PageHeaderExtra", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Breadcrumb",PropertyName="PageHeaderBreadcrumb", IsAttribute =false },
                new ContainsElementPropertyViewModel{ PropertyDisplayName = "Avatar",PropertyName="PageHeaderAvatar", IsAttribute =false },
            }
        };
        public static ComponentViewModel IconViewModel { get; } = new IconComponentViewModel()
        {
            ControlName= "Icon",
            ControlDisplayName = "Icon",
            DefaultMarkup = @"<Icon Type=""ant-design"" Theme=""outline""/>",
            Moniker = KnownMonikers.ImageIcon,
        };
        public static ComponentViewModel DropdownButtonViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "DropdownButton",
            ControlDisplayName = "DropdownButton",
            DefaultMarkup = @"<DropdownButton>
    <Overlay>
        
    </Overlay>
    <ChildContent>
        
    </ChildContent>
</DropdownButton>
",
            Moniker = KnownMonikers.ComboBoxItem,
            Properties = new OCP
            {
                EnumOptionHelper.GetOptionsViewModel<ButtonSize>("Size"),
                EnumOptionHelper.GetOptionsViewModel<ButtonType>("Type"),
                new BP(){ PropertyName = "Danger" },
                new BP(){ PropertyName = "Ghost" },
                new BP(){ PropertyName = "Loading" },
                new ContainsElementPropertyViewModel(){ PropertyName="Overlay", PropertyDisplayName="Overlay", DefaultValue = true, Value = true, IgnoreOnDefault = false },
                new ContainsElementPropertyViewModel(){ PropertyName="ChildContent", PropertyDisplayName="ChildContent", DefaultValue = true, Value = true, IgnoreOnDefault = false }
            }
        };
        public static ComponentViewModel DropdownViewModel { get; } = new ComponentViewModel()
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
                EnumOptionHelper.GetOptionsViewModel<Placement>("Placement"),
                new ContainsElementPropertyViewModel(){ PropertyName="Overlay", PropertyDisplayName="Overlay", DefaultValue = true, Value = true, IgnoreOnDefault = false },
                new ContainsElementPropertyViewModel(){ PropertyName="ChildContent", PropertyDisplayName="ChildContent", DefaultValue = true, Value = true, IgnoreOnDefault = false },
                new BP() { PropertyName = "IsButton" }
            }
        };
        public static ComponentViewModel MenuViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Menu",
            ControlDisplayName = "Menu",
            DefaultMarkup = @"<Menu>
  <MenuItem>Menu</MenuItem>
  <SubMenu Title=""SubMenu"">
    <MenuItem>SubMenuItem</MenuItem>
  </SubMenu>
</Menu>
",
            Moniker = KnownMonikers.MainMenuControl,
            Properties = new OCP
            {
                EnumOptionHelper.GetOptionsViewModel<MenuMode>("Mode"),
                EnumOptionHelper.GetOptionsViewModel<MenuTheme>("Theme"),
                new IntegerOrIteratorPropertyViewModel(){ PropertyDisplayName = "Children", PropertyName = "Children", ChildrenTagName = "MenuItem"},
                new BP{ PropertyName="InlineCollapsed" },
                new BP{ PropertyName="Multiple" },
                new BP{ PropertyName="Selectable" }
            }
        };
        public static ComponentViewModel SubmenuViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "SubMenu",
            ControlDisplayName = "Menu - SubMenu",
            DefaultMarkup = @"<SubMenu Key=""sub1"" Title=""Sub Menu"">
     <MenuItem Key=""1"">Option 1</MenuItem>
     <MenuItem Key=""2"">Option 2</MenuItem>
     <MenuItem Key=""3"">Option 3</MenuItem>
     <MenuItem Key=""4"">Option 4</MenuItem>
</SubMenu>
",
            Moniker = KnownMonikers.MainMenuControl,
            Properties = new OCP
            {
                new BP{ PropertyName="IsOpen" },
                new BP{ PropertyName="Disabled" },
                new SP{ PropertyName = "Key", IgnoreOnDefault = false },
                new SP{ PropertyName = "Title", IgnoreOnDefault = false },
            }
        };
        public static ComponentViewModel MenuItemViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "SubMenu",
            ControlDisplayName = "Menu - MenuItem",
            DefaultMarkup = @"<MenuItem Key=""key"">SubMenuItem</MenuItem>
",
            Moniker = KnownMonikers.MainMenuControl,
            Properties = new OCP
            {
                new BP{ PropertyName="Disabled" },
                new SP{ PropertyName = "Key", IgnoreOnDefault = false},
                new SP{ PropertyName = "Title", IgnoreOnDefault = false},
                new SP{ PropertyName = "RouterLink" },
                EnumOptionHelper.GetOptionsViewModel<NavLinkMatch>("RouterMatch"),
            }
        };
        public static ComponentViewModel PaginationViewModel { get; } = new ComponentViewModel()
        {
            ControlName = "Pagination",
            ControlDisplayName = "Pagination",
            DefaultMarkup = @"<Pagination PageIndex=""1"" Total=""50""></Pagination>",
            Moniker = KnownMonikers.DottedSplitter,
            Properties = new OCP
            {
                new IntegerPropertyViewModel{ PropertyName="Current", PropertyDisplayName = "Current", DefaultValue = null, Value = null},
                new IntegerPropertyViewModel{ PropertyName="DefaultCurrent", PropertyDisplayName = "Current", DefaultValue = 1, Value = 1},
                new IntegerPropertyViewModel{ PropertyName="Current", PropertyDisplayName = "Current", DefaultValue = 10, Value = 10 },
                new IntegerPropertyViewModel{ PropertyName="PageSize", PropertyDisplayName = "PageSize", DefaultValue = 50, Value = 50 },
                new BP{ PropertyName = "Simple", PropertyDisplayName = "Simple" },
                new BP{ PropertyName = "Disabled", PropertyDisplayName = "Disabled" },
                new BP{ PropertyName = "HideOnSinglePage", PropertyDisplayName = "Hide On Single Page" },
                new BP{ PropertyName = "ShowQuickJumper", PropertyDisplayName = "Show Quick Jumper" },
                new BP{ PropertyName = "ShowSizeChanger", PropertyDisplayName = "Show Size Changer" },
                new IntegerPropertyViewModel{ PropertyName="TotalBoundaryShowSizeChanger", PropertyDisplayName = "TotalBoundaryShowSizeChanger", DefaultValue = 50, Value = 50 },
                new BP{ PropertyName = "ShowTitle", PropertyDisplayName = "Show Title" },
            }
        };


        private static ComponentViewModel SampleViewModel = new ComponentViewModel()
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
        public static StringOptionsViewModel GetOptionsViewModel<T>(string propertyName, bool ignoreOnDefault = false) where T: System.Enum
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
                IgnoreOnDefault = ignoreOnDefault,
            };
        }
    }
}
