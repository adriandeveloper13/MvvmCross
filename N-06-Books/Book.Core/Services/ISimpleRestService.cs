using System;

namespace Book.Core.Services
{
    public interface ISimpleRestService
    {
        //verb represent a  GET or POST action
        void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);
    }
}