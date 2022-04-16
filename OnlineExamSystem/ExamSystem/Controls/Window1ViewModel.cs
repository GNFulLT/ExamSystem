using ExamSystem.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Controls
{
    public class Window1ViewModel :ObservableObject
    {
        private List<int> _sourceList = new List<int>();

        public ObservableCollection<int> PaginationCollection { get; set; } = new ObservableCollection<int>();


        public Window1ViewModel()
        {
            _sourceList.AddRange(Enumerable.Range(1, 300));
            Count = 300;
            UpdatePage();
        }

        private void UpdatePage()
        {
            PaginationCollection.Clear();

            foreach(var item in _sourceList.Skip((Current - 1) * CountPerPage).Take(CountPerPage))
            {
                PaginationCollection.Add(item);
            }
        }


        private int _countPerPage = 10;
        public int CountPerPage
        {
            get { return _countPerPage; }
            set { _countPerPage = value; NotifyPropertyChanged();
                UpdatePage();
            }
        }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value;
                NotifyPropertyChanged();
            }
        }
        private int _current = 1;
        public int Current
        {
            get { return _current; }
            set { _current = value; this.NotifyPropertyChanged(); UpdatePage(); }
        }


    }
}
