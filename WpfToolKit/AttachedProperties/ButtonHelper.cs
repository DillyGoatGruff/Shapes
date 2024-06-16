using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfToolKit.AttachedProperties
{
    public class ButtonHelper : DependencyObject
    {

        #region DialogResultValue

        public static bool GetDialogValueResult(Button obj)
        {
            return (bool)obj.GetValue(DialogValueResultProperty);
        }

        public static void SetDialogValueResult(Button obj, bool value)
        {
            obj.SetValue(DialogValueResultProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for DialogValueResult.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DialogValueResultProperty =
            DependencyProperty.RegisterAttached("DialogValueResult", typeof(bool), typeof(ButtonHelper), new PropertyMetadata(false, OnDialogResultValueChanged));

        private static void OnDialogResultValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is not Button b)
            {
                return;
            }

            b.Click += (s, e) =>
            {
                Window w = Window.GetWindow(b);
                try
                {
                    w.DialogResult = GetDialogValueResult(b);
                }
                catch(InvalidOperationException)
                {
                    //This will be thrown if a window is displayed by calling .Show() instead of .ShowDialog()
                }
            };
        }

        #endregion
    }
}
