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
    public class AddProcessCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public AddProcessCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // add selected process
            if(_viewModel.SelectedProcess != null)
            {
                using(var DbContext = new DatabaseEntities())
                {
                    DbContext.Processes.Add((_viewModel.SelectedProcess as Process));
                    DbContext.SaveChanges();
                    (parameter as ItemCollection).Refresh();
                }

                return;
            }

            if(_viewModel.DescriptionProcess == null || _viewModel.SubjectId == null || _viewModel.StartDate == null || _viewModel.EndDate == null ||
                _viewModel.UsedEmployeeNumber == null || _viewModel.Department == null)
            {
                MessageBox.Show("Please enter text to textboxes");
                return;
            }

            // add process
            Process process = CreateProcess();

            if(process == null)
                return;

            using (var DbContext = new DatabaseEntities())
            {
                var subject = DbContext.Subjects
                    .Where(t => t.Id == process.UsedSubject)
                    .FirstOrDefault();

                if (subject == default)
                {
                    MessageBox.Show("this subject doesn't exists, please try again");
                    return;
                }

                DbContext.Processes.Add(process);
                DbContext.SaveChanges();

                _viewModel.Processes.Add(process);
                (parameter as ItemCollection).Refresh();
            }
        }

        private Process CreateProcess()
        {
            int subjectId;
            int employeeNumber;

            try
            {
                subjectId = Convert.ToInt32(_viewModel.SubjectId);
                employeeNumber = Convert.ToInt32(_viewModel.UsedEmployeeNumber);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            Process process = new Process()
            {
                Description = _viewModel.DescriptionProcess,
                UsedSubject = subjectId,
                StartDate = Convert.ToDateTime(_viewModel.StartDate),
                EndDate = Convert.ToDateTime(_viewModel.EndDate),
                UsedEmployeeNumber = employeeNumber,
                Department = _viewModel.Department,
                IsCompleted = "не выполнено"
            };

            return process;
        }
    }
}
