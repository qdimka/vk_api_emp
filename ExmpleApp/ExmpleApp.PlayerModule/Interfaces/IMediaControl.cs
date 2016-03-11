using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExmpleApp.PlayerModule.Interfaces
{
    public interface IMediaControl
    {
       ICommand PlayCommand { get; set; }
       ICommand PauseCommand { get; set; }
       ICommand StopCommand { get; set; }
    }
}
