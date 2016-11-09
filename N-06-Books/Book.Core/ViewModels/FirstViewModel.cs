using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Book.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IBooksService _books;

        public FirstViewModel(IBooksService books)
        {
            _books = books;
        }

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                RaisePropertyChanged(() => SearchTerm);
                Update();
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

        private void Update()
        {
            _books.StartSearchAsync(SearchTerm, 
                result => Results = result.items, 
                error => { });
        }
    }
}