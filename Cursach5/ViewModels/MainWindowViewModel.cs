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

        private string _descriptionProcess;
        private string _subjectId;
        private object _startDate;
        private object _endDate;

        private List<Process> _processes;
        private object _selectedProcess;

        public ICommand AddSubject => new AddSubjectCommand(this);
        public ICommand DeleteSubject => new DeleteSubjectCommand(this);
        public ICommand UpdateSubjects => new UpdateSubjectsCommand(this);

        public ICommand AddProcess => new AddProcessCommand(this);
        public ICommand DeleteProcess => new DeleteProcessCommand(this);
        public ICommand MarkProcess => new MarkProcessCommand(this);

        public MainWindowViewModel()
        {
            using(var dbContext = new DatabaseEntities())
            {
                _subjects = dbContext.Subjects
                    .ToList();

                _processes = dbContext.Processes
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



        public List<Process> Processes
        {
            get => _processes;
            set => Set(ref _processes, value, nameof(Processes));
        }

        public object SelectedProcess
        {
            get => _selectedProcess;
            set => Set(ref _selectedProcess, value, nameof(SelectedProcess));
        }

        public string DescriptionProcess
        {
            get => _descriptionProcess;
            set => Set(ref _descriptionProcess, value, nameof(DescriptionProcess));
        }

        public string SubjectId
        {
            get => _subjectId;
            set => Set(ref _subjectId, value, nameof(SubjectId));
        }

        public object StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value, nameof(StartDate));
        }

        public object EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value, nameof(EndDate));
        }
    }
}
