using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Book.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.DownloadCache;

namespace Book.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly object _lockObject = new Object();//I've added a sync object , so I can do multiThreading  without to worry about
        // _lockObject allows me to access a resource, or to call a method   without to worry about threading conflicts
        private MvxFileDownloadCache.Timer _timer;
        private readonly IBooksService _books;
        public FirstViewModel(IBooksService books)
        {
            _books = books;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged( () => IsLoading);
            }

        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                RaisePropertyChanged(() => SearchTerm);
                ScheduleUpdate();
            }
        }

        private void ScheduleUpdate()
        {
            lock (_lockObject)
            {
                //if (_timer != null)
                //{
                    _timer = new MvxFileDownloadCache.Timer(OnTimerTick, null, TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
                //}
                //else
                //{
                //    _timer.Change(TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
                //}
            }
        }


        private List<BookSearchItem> _results;

        public List<BookSearchItem> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged(() => Results);
            }
        }

        private void OnTimerTick(object state)
        {
            lock (_lockObject)
            {
                _timer.Dispose();
                _timer = null;
                Update();
            }
        }

        private void Update()
        {
            IsLoading = true;
            _books.StartSearchAsync(SearchTerm,
                result =>
                {
                    IsLoading = false;
                    Results = result.items;
                },

                error =>
                {
                    IsLoading = false;
                });
        }
    }
}