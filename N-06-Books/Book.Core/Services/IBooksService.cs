using System;

namespace Book.Core.Services
{
    public interface IBooksService
    {
        void StartSearchAsync(string whatFor, Action<BookSearchResult> success, Action<Exception> error);
    }
}