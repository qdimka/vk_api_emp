using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ExmpleApp.PlayerModule.Behaviors
{
    public class SelectorSelectionChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
        public static ICommand GetCommand(Selector selector)
                            => selector.GetValue(CommandProperty) as ICommand;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
        public static void SetCommand(Selector selector, ICommand value)
                            => selector.SetValue(CommandProperty, value);

        private static readonly DependencyProperty SelectCommandBehaviorProperty =
            DependencyProperty.RegisterAttached("SelectCommandBehavior", typeof(SelectorSelectedCommandBehavior),
            typeof(SelectorSelectionChanged), null);

        private static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand),
            typeof(SelectorSelectionChanged), new PropertyMetadata(OnSetCommandCallback));

        private static void OnSetCommandCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var selector = obj as Selector;
            if (selector != null)
            {
                GetOrCreateBehavior(selector).Command = e.NewValue as ICommand;
            }
        }

        private static SelectorSelectedCommandBehavior GetOrCreateBehavior(Selector selector)
        {
            var behavior = selector.GetValue(SelectCommandBehaviorProperty) as SelectorSelectedCommandBehavior;

            if (behavior == null)
            {
                behavior = new SelectorSelectedCommandBehavior(selector);
                selector.SetValue(SelectCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}
