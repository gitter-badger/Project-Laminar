using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Laminar_PluginFramework.Primitives;
using System.Diagnostics;

namespace Laminar_Inbuilt.UserControls
{
    public class EnumEditor : UserControl
    {
        public EnumEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContextChanged += EnumEditor_DataContextChanged;
        }

        private void EnumEditor_DataContextChanged(object sender, System.EventArgs e)
        {
            this.FindControl<ComboBox>("CBox").Items = (DataContext as ILaminarValue)?.TypeDefinition.ValueType.GetEnumValues();
        }
    }
}
