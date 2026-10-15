namespace Identity.Application.Services.InfrastructureContract;
/// <summary>
/// Универсальный регистратор сущностей в контексте базы данных.
/// </summary>
public interface IDbContextStateAdder
{
    /// <summary>
    /// Регистрирует новые записи для последующей вставки в базу данных.
    /// </summary>
    /// <param name="dbRecords">Массив доменных сущностей или записей БД, готовых к сохранению</param>
    Task AddRangeAsync(CancellationToken ct, params object[] dbRecords);
}
