using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrentItemViewModel:BindableBase
    {
        [ImportingConstructor]
        public CurrentItemViewModel()
        {

        }
    }
}
