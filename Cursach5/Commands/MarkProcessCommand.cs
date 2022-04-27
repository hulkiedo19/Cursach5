using Cursach5.Models;
using Cursach5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cursach5.Commands
{
    public class MarkProcessCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public MarkProcessCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.SelectedProcess == null)
            {
                MessageBox.Show("please select the process");
                return;
            }

            if((_viewModel.SelectedProcess as Process).IsCompleted != "не выполнено")
                return;

            int ProcessId = (_viewModel.SelectedProcess as Process).Id;

            using (var DbContext = new DatabaseEntities())
            {
                var process = DbContext.Processes
                    .Where(p => p.Id == ProcessId)
                    .First();

                process.IsCompleted = "завершено";

                DbContext.SaveChanges();
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
