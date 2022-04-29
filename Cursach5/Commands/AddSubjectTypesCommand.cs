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
    public class AddSubjectTypesCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public AddSubjectTypesCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.SelectedSubjectType != null)
            {
                using(var DbContext = new DatabaseEntities())
                {
                    DbContext.SubjectTypes.Add((_viewModel.SelectedSubjectType as SubjectType));
                    DbContext.SaveChanges();
                    (parameter as ItemCollection).Refresh();
                }
                return;
            }

            if(_viewModel.Name == null || _viewModel.DescriptionSubjectType == null)
            {
                MessageBox.Show("Please enter text to textboxes");
                return;
            }

            SubjectType subjectType = CreateSubjectType();

            using(var DbContext = new DatabaseEntities())
            {
                DbContext.SubjectTypes.Add(subjectType);
                DbContext.SaveChanges();

                _viewModel.SubjectTypes.Add(subjectType);
                (parameter as ItemCollection).Refresh();
            }
        }

        private SubjectType CreateSubjectType()
        {
            SubjectType subjectType = new SubjectType()
            {
                Name = _viewModel.Name,
                Description = _viewModel.DescriptionSubjectType
            };

            return subjectType;
        }
    }
}
