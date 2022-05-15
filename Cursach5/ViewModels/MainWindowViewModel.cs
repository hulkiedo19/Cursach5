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
        private string _subjectTypeId;
        private string _invNumber;
        private string _amountSubjects;

        private List<Subject> _subjects;
        private object _selectedSubject;

        private string _descriptionProcess;
        private string _subjectId;
        private object _startDate;
        private object _endDate;
        private string _usedEmployeeNumber;
        private string _department;

        private List<Process> _processes;
        private object _selectedProcess;

        private string _name;
        private string _descriptionSubjectType;

        private List<SubjectType> _subjectTypes;
        private object _selectedSubjectType;

        public ICommand AddSubject => new AddSubjectCommand(this);
        public ICommand DeleteSubject => new DeleteSubjectCommand(this);
        public ICommand UpdateSubjects => new UpdateSubjectsCommand(this);

        public ICommand AddProcess => new AddProcessCommand(this);
        public ICommand DeleteProcess => new DeleteProcessCommand(this);
        public ICommand MarkProcess => new MarkProcessCommand(this);
        public ICommand UpdateProcess => new UpdateProcessCommand(this);

        public ICommand AddSubjectType => new AddSubjectTypesCommand(this);
        public ICommand DeleteSubjectType => new DeleteSubjectTypesCommand(this);
        public ICommand UpdateSubjectType => new UpdateSubjectTypesCommand(this);

        public MainWindowViewModel()
        {
            using(var dbContext = new DatabaseEntities())
            {
                _subjects = dbContext.Subjects
                    .Include(nameof(Subject.SubjectType1))
                    .ToList();

                _processes = dbContext.Processes
                    .ToList();

                _subjectTypes = dbContext.SubjectTypes
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

        public string SubjectTypeId
        {
            get => _subjectTypeId;
            set => Set(ref _subjectTypeId, value, nameof(SubjectTypeId));
        }

        public string InvNumber
        {
            get => _invNumber;
            set => Set(ref _invNumber, value, nameof(InvNumber));
        }

        public string AmountSubjects
        {
            get => _amountSubjects;
            set => Set(ref _amountSubjects, value, nameof(AmountSubjects));
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

        public string UsedEmployeeNumber
        {
            get => _usedEmployeeNumber;
            set => Set(ref _usedEmployeeNumber, value, nameof(UsedEmployeeNumber));
        }

        public string Department
        {
            get => _department;
            set => Set(ref _department, value, nameof(Department));
        }


        public List<SubjectType> SubjectTypes
        {
            get => _subjectTypes;
            set => Set(ref _subjectTypes, value, nameof(SubjectTypes));
        }

        public object SelectedSubjectType
        {
            get => _selectedSubjectType;
            set => Set(ref _selectedSubjectType, value, nameof(SelectedSubjectType));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public string DescriptionSubjectType
        {
            get => _descriptionSubjectType;
            set => Set(ref _descriptionSubjectType, value, nameof(DescriptionSubjectType));
        }
    }
}
