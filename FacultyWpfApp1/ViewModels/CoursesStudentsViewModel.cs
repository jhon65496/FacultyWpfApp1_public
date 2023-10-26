using FacultyWpfApp1.Data;
using FacultyWpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacultyWpfApp1.ViewModels
{
    class CoursesStudentsViewModel : BaseVM
    {
        DataContextApp dc;
        // ctor
        public CoursesStudentsViewModel(DataContextApp dc)
        {
            this.dc = dc;
        }


        // Courses
        private ObservableCollection<CourseStudent> _сourseStudent;

        public ObservableCollection<CourseStudent> CourseStudents
        {
            get { return _сourseStudent; }
            set { _сourseStudent = value; }
        }


        // SelectedCourse
        private CourseStudent _selectedCoursesStudents;

        public CourseStudent SelectedCoursesStudents
        {
            get { return _selectedCoursesStudents; }
            set
            {
                _selectedCoursesStudents = value;


                if (_selectedCoursesStudents  == null) return;
                Debug.WriteLine($"--- --- --- --- --- --- --- --- ---");
                // Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- {_selectedCoursesStudents.NameCourse}");
                if (this._selectedCoursesStudents == null)
                {
                    Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- managerIndexesViewModel = null\n");
                    return;
                }

                // this.managerIndexesViewModel.SelectedIndexCalculation = selectedIndexCalculation;


                RaisePropertyChanged(nameof(SelectedCoursesStudents));
            }
        }


        public void LoadDataTest()
        {
            // СalculationIndexs = this.DataContextApp.СalculationIndexes;
            CourseStudents = dc.CourseStudents;
            // return dc.Courses;

            Debug.WriteLine($"\n\n === === === IndexesViewModel === === === ");
            // Debug.WriteLine($"СalculationIndexs.Count -- {СalculationIndexs.Count}");
        }
    }
}
