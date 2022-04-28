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
    public class DeleteSubjectCommand : Command
    {
        private MainWindowViewModel _viewModel;

        public DeleteSubjectCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            int subjectId = (_viewModel.SelectedSubject as Subject).Id;

            using(var DbContext = new DatabaseEntities())
            {
                var subject = DbContext.Subjects
                    .Where(s => s.Id == subjectId)
                    .Single();

                if(subject.Processes.Count() > 0)
                {
                    MessageBox.Show("Please finish all processes before deleting subject");
                    return;
                }

                DbContext.Subjects.Remove(subject);
                DbContext.SaveChanges();

                _viewModel.Subjects.Remove(subject);
                (parameter as ItemCollection).Refresh();
            }

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
