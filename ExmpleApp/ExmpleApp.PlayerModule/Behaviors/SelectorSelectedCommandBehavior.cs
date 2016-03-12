using Prism.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExmpleApp.PlayerModule.Behaviors
{
    public class SelectorSelectedCommandBehavior:CommandBehaviorBase<Selector>
    {
        public SelectorSelectedCommandBehavior(Selector selector):base(selector)
        {
            selector.SelectionChanged += OnSelectorSelectionChanged;
        }

        private void OnSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommandParameter = TargetObject.SelectedItem;
            this.ExecuteCommand(CommandParameter);
        }
    }
}
