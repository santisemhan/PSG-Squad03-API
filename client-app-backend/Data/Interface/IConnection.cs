namespace client_app_backend.Data.Interface
{
    public interface IConnection<T> where T : class
    {
        public T GetConnection();
    }
}
