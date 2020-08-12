using GettingStarted_NumericTextBox;
using GettingStarted_NumericTextBox.UWP;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.SfNumericTextBox.XForms.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomNumericTextBox), typeof(CustomNumericTextBoxRenderer))]
namespace GettingStarted_NumericTextBox.UWP
{
    public class CustomNumericTextBoxRenderer : SfNumericTextBoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
        {
            base.OnElementChanged(e);
            
            if (Control != null)
            {
                Control.ShowClearButton = false;
            }
        }

       
    }
}
