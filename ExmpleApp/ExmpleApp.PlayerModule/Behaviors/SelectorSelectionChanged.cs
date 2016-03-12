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
    //public static class Selected
    //{
    //    private static readonly DependencyProperty SelectedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
    //        "SelectedCommandBehavior",
    //        typeof(SelectorSelectedCommandBehavior),
    //        typeof(Selected),
    //        null);

    //    public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
    //        "Command",
    //        typeof(ICommand),
    //        typeof(Selected),
    //        new PropertyMetadata(OnSetCommandCallback));

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
    //    public static void SetCommand(Selector selector, ICommand command)
    //    {
    //        selector.SetValue(CommandProperty, command);
    //    }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
    //    public static ICommand GetCommand(Selector selector)
    //    {
    //        return selector.GetValue(CommandProperty) as ICommand;
    //    }

    //    private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    //    {
    //        var selector = dependencyObject as Selector;
    //        if (selector != null)
    //        {
    //            GetOrCreateBehavior(selector).Command = e.NewValue as ICommand;
    //        }
    //    }

    //    private static SelectorSelectedCommandBehavior GetOrCreateBehavior(Selector selector)
    //    {
    //        var behavior = selector.GetValue(SelectedCommandBehaviorProperty) as SelectorSelectedCommandBehavior;
    //        if (behavior == null)
    //        {
    //            behavior = new SelectorSelectedCommandBehavior(selector);
    //            selector.SetValue(SelectedCommandBehaviorProperty, behavior);
    //        }

    //        return behavior;
    //    }
    //}





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
