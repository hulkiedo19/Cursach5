using Cursach5.Models;
using Cursach5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cursach5.Commands
{
    public class UpdateProcessCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public UpdateProcessCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            UpdateProcesses();
            (parameter as ItemCollection).Refresh();
        }

        private void UpdateProcesses()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _viewModel.Processes = DbContext.Processes.ToList();
            }
        }
    }
}
