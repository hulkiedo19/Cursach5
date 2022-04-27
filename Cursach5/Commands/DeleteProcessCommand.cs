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
    public class DeleteProcessCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public DeleteProcessCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            int ProcessId = (_viewModel.SelectedProcess as Process).Id;

            using (var DbContext = new DatabaseEntities())
            {
                var process = DbContext.Processes
                    .Where(p => p.Id == ProcessId)
                    .Single();

                DbContext.Processes.Remove(process);
                DbContext.SaveChanges();

                _viewModel.Processes.Remove(process);
                (parameter as ItemCollection).Refresh();
            }

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
