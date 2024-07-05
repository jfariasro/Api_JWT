namespace AppApi.Services.Interfaces
{
    public interface IGenericService<TEntityModel> where TEntityModel : class
    {
        Task<bool> Registrar(TEntityModel entity);
        Task<bool> Editar(TEntityModel entity, int id);
        Task<bool> Eliminar(int id);
        Task<IQueryable<TEntityModel>> Consultar();
        Task<TEntityModel> Buscar(int id);

    }
}
