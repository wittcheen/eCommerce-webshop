using System.Linq.Expressions;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;

namespace eCommerce.Mapping
{
    public static class MapsterConfig
    {
        public static void Register()
        {
            RegisterIdMap<User, UserResponseDTO>(s => s.UserID);
            RegisterIdMap<Category, CategoryResponseDTO>(s => s.CategoryID);
            RegisterIdMap<Product, ProductResponseDTO>(s => s.ProductID);
            RegisterIdMap<Image, ImageResponseDTO>(s => s.ImageID);
            RegisterIdMap<Customer, CustomerResponseDTO>(s => s.CustomerID);
            RegisterIdMap<OrderItem, OrderItemResponseDTO>(s => s.OrderItemID);
            RegisterIdMap<Order, OrderResponseDTO>(s => s.OrderID);
        }

        private static void RegisterIdMap<TSource, TDestination>(
            Expression<Func<TSource, object>> sourceId)
        {
            TypeAdapterConfig.GlobalSettings
                .NewConfig<TSource, TDestination>().Map("ID", sourceId);
        }
    }
}
