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
    public class DeleteSubjectTypesCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public DeleteSubjectTypesCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            int subjectTypeId = (_viewModel.SelectedSubjectType as SubjectType).SubjectTypeId;

            using (var DbContext = new DatabaseEntities())
            {
                var subjectType = DbContext.SubjectTypes
                    .Where(t => t.SubjectTypeId == subjectTypeId)
                    .Single();

                if (subjectType.Subjects.Count > 0)
                {
                    MessageBox.Show("Please delete all subject before deleting subjectType");
                    return;
                }

                DbContext.SubjectTypes.Remove(subjectType);
                DbContext.SaveChanges();

                _viewModel.SubjectTypes.Remove(subjectType);
                (parameter as ItemCollection).Refresh();
            }

            UpdateSubjectTypes();
            (parameter as ItemCollection).Refresh();
        }

        private void UpdateSubjectTypes()
        {
            using(var DbContext = new DatabaseEntities())
            {
                _viewModel.SubjectTypes = DbContext.SubjectTypes
                    .ToList();
            }
        }
    }
}
