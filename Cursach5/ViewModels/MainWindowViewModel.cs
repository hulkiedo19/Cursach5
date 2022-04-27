using Cursach5.Commands;
using Cursach5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cursach5.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _name;
        private string _description;
        private string _invNumber;
        private string _quantity;

        private List<Subject> _subjects;
        private object _selectedSubject;

        public ICommand AddSubject => new AddSubjectCommand(this);
        public ICommand DeleteSubject => new DeleteSubjectCommand(this);
        public ICommand UpdateSubjects => new UpdateSubjectsCommand(this);

        public MainWindowViewModel()
        {
            using(var dbContext = new DatabaseEntities())
            {
                _subjects = dbContext.Subjects
                    .ToList();
            }
        }

        public List<Subject> Subjects
        {
            get => _subjects;
            set => Set(ref _subjects, value, nameof(Subjects));
        }

        public object SelectedSubject
        {
            get => _selectedSubject;
            set => Set(ref _selectedSubject, value, nameof(SelectedSubject));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value, nameof(Description));
        }

        public string InvNumber
        {
            get => _invNumber;
            set => Set(ref _invNumber, value, nameof(InvNumber));
        }

        public string Quantity
        {
            get => _quantity;
            set => Set(ref _quantity, value, nameof(Quantity));
        }
    }
}
