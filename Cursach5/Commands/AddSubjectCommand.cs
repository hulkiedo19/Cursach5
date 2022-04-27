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

            if(_viewModel.Name == null || _viewModel.Description == null || _viewModel.InvNumber == null || _viewModel.Quantity == null)
            {
                MessageBox.Show("Please enter text to textboxes");
                return;
            }

            // add default subject
            Subject subject = CreateSubject();

            using(var DbContext = new DatabaseEntities())
            {
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
                Name = _viewModel.Name,
                Description = _viewModel.Description,
                InventoryNumber = _viewModel.InvNumber,
                Quantity = Convert.ToInt32(_viewModel.Quantity)
            };

            return subject;
        }
    }
}
