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
                Control.Loaded += Control_Loaded;
            }
        }

        private void Control_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            FindChildControl<Button>(Control, "DeleteButton");
        }
        public DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement FrameElement = child as FrameworkElement;
                if (FrameElement == null) return null;

                if ((FrameElement is Grid))
                {
                    UIElement FrameElementChild = (FrameElement as Grid).Children[1];
                    if (FrameElementChild is Grid)
                    {
                        UIElement CloseButton = (FrameElementChild as Grid).Children[6];
                        if ((CloseButton as Button).Name == ctrlName)
                        {
                            (CloseButton as Button).Width = 0;
                            (CloseButton as Button).Height = 0;
                        }
                    }
                    return child;
                }
                else
                {
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }
    }
}
