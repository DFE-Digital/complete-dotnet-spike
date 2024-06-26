﻿namespace Dfe.Complete.API.Contracts.Common
{
    public sealed class ApiListWrapper<T>
    {
        public IList<T> Data { get; }

        public PagingResponse Paging { get; }

        public ApiListWrapper(IList<T> data, PagingResponse paging) => (Data, Paging) = (data, paging);
    }
}
