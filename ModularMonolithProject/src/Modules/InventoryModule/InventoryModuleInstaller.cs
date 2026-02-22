using Microsoft.Extensions.DependencyInjection;
// Sadece bu modülün içindeki (Internal) sınıfları bilir

namespace InventoryModule.Core;

public static class InventoryModuleInstaller
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services, string connectionString)
    {
        // 1. Modülün kendi veritabanı kaydı
        services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString));

        // 2. Modülün kendi servisleri (Dışarıya sadece Interface ile açılır)
        services.AddScoped<IInventoryService, InventoryService>();

        return services;
    }
}