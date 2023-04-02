using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoinViewer.Utilities
{
    internal class CustomRadioButton : RadioButton
    {
        static CustomRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadioButton),
                new FrameworkPropertyMetadata(typeof(CustomRadioButton)));
        }
    }
}
