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
    public class UpdateSubjectsCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public UpdateSubjectsCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            UpdateSubjects();
            (parameter as ItemCollection).Refresh();
        }

        private void UpdateSubjects()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _viewModel.Subjects = DbContext.Subjects
                    .Include(nameof(Subject.SubjectType1))
                    .ToList();
            }
        }
    }
}
