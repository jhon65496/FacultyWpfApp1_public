using FacultyWpfApp1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacultyWpfApp1.ViewModels;
using FacultyWpfApp1.Views;
using System.Diagnostics;
using FacultyWpfApp1.Models;

namespace FacultyWpfApp1.ViewModels
{
    class MainWindowViewModel : BaseVM
    {
        public DataContextApp dc;

        CoursesViewModel coursesViewModel;
        CoursesStudentsJoinViewModel coursesStudentsJoinViewModel;
        public MainWindowViewModel(DataContextApp dc)
        {
            this.dc = dc;

            // CoursesViewModel
            this.coursesViewModel = new CoursesViewModel(this);
            coursesViewModel.LoadDataTest();

            CoursesView cView = new CoursesView();
            cView.DataContext = coursesViewModel;
            CoursesView = coursesViewModel;

            // CoursesStudentsJoinViewModel
            coursesStudentsJoinViewModel = new CoursesStudentsJoinViewModel(this.dc);
            coursesStudentsJoinViewModel.LoadDataTest();

            CoursesStudentsJoinView csView = new CoursesStudentsJoinView();
            csView.DataContext = coursesStudentsJoinViewModel;
            CoursesStudentsJoinView = coursesStudentsJoinViewModel;


            // Prop
            // this.SelectedCourse = coursesViewModel.SelectedCourse;
        }


        // SelectedCourse
        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                Debug.WriteLine("\n\n === === === MainWindowViewModel.SelectedCourse === === ===");
                if (selectedCourse == null)
                {
                    Debug.WriteLine($"SelectedCourse = null !!!");
                    return;
                }
                Debug.WriteLine($"SelectedCourse.NameCourse -- {selectedCourse.NameCourse}");

                // Установить критерий фильтрации
                coursesStudentsJoinViewModel.CourseFilter = selectedCourse;

                RaisePropertyChanged(nameof(SelectedCourse));
            }
        }


        /// <summary>
        /// View
        /// </summary>
        #region View === === === === === === === === ===
        // CoursesView
        private BaseVM coursesView;

        public BaseVM CoursesView
        {
            get { return coursesView; }
            set
            {
                coursesView = value;
                RaisePropertyChanged(nameof(CoursesView));
            }
        }


        // CourseStudentsView
        private BaseVM _сoursesStudentsJoinView;

        public BaseVM CoursesStudentsJoinView
        {
            get { return _сoursesStudentsJoinView; }
            set
            {
                _сoursesStudentsJoinView = value;
                RaisePropertyChanged(nameof(CoursesStudentsJoinView));
            }
        }


        #endregion
    }
}
