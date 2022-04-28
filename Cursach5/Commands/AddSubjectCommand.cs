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
    public class AddSubjectCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public AddSubjectCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // add selected subject
            if(_viewModel.SelectedSubject != null)
            {
                using (var DbContext = new DatabaseEntities())
                {
                    DbContext.Subjects.Add((_viewModel.SelectedSubject as Subject));
                    DbContext.SaveChanges();
                    (parameter as ItemCollection).Refresh();
                }

                return;
            }

            if(_viewModel.SubjectTypeId == null || _viewModel.InvNumber == null || _viewModel.AmountSubjects == null)
            {
                MessageBox.Show("Please enter text to textboxes");
                return;
            }

            // add default subject
            Subject subject = CreateSubject();

            using(var DbContext = new DatabaseEntities())
            {
                var SubjectType = DbContext.SubjectTypes
                    .Where(x => x.SubjectTypeId == subject.SubjectType)
                    .FirstOrDefault();

                if(SubjectType == default)
                {
                    MessageBox.Show("this type of subject doesn't exists, please try again");
                    return;
                }

                subject.SubjectType1 = SubjectType;

                DbContext.Subjects.Add(subject);
                DbContext.SaveChanges();

                _viewModel.Subjects.Add(subject);
                (parameter as ItemCollection).Refresh();
            }
        }

        private Subject CreateSubject()
        {
            Subject subject = new Subject()
            {
                SubjectType = Convert.ToInt32(_viewModel.SubjectTypeId),
                InventoryNumber = _viewModel.InvNumber,
                AmountSubjects = Convert.ToInt32(_viewModel.AmountSubjects)
            };

            return subject;
        }
    }
}
