namespace WHM.FE.Services.Interfaces
{
    public interface IApiCallerGeneric
    {
        public Task<T?> GetApiData<T>(string url, string apiFactoryName);
        public Task<bool> PostApi<T>(string url, T requestObject, string apiFactoryName);
        public Task<TOut?> PostApi<T, TOut>(string url, T requestObject, string apiFactoryName);
        public Task<bool> PostApiFormData(string url, FormUrlEncodedContent formContent, string apiFactoryName);
        public Task<bool> PutData<T>(string url, T objectRequest, string apiFactoryName);
        public Task<bool> DeleteData<T>(string url, string apiFactoryName);
    }
}
