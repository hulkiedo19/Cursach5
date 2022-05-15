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
    public class UpdateSubjectTypesCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public UpdateSubjectTypesCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            UpdateSubjectTypes();
            (parameter as ItemCollection).Refresh();
        }

        private void UpdateSubjectTypes()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _viewModel.SubjectTypes = DbContext.SubjectTypes
                    .ToList();
            }
        }
    }
}
