namespace My_Login_App.API.Interfaces
{
    public interface IPKG_BASE<T, V>
    {
        void AddEntity(T entity);

        void UpdateEntity(int id, T entity);

        void DeleteEntity(int id);

        V GetEntity(int id);

        V GetEntityByProperty(string propertyName);

        List<V> GetAllEntities();
    }
}
