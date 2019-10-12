using System;
using Microsoft.EntityFrameworkCore;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Contracts.Enums;

namespace Roxosoft.Orders.Api.DAL.Context {
    /// <summary>
    /// Отвечает за заполнение базы изначальными данными
    /// </summary>
    public class OrdersInitialDataCreator {
        public static void Create(ModelBuilder modelBuilder) {
            //NOTE: в реальности эти данные следовало бы считывать из json-конфигов
            
            modelBuilder.Entity<ProductDto>().HasData
            (
                new ProductDto {Id = 1, Name = "Масло"},
                new ProductDto {Id = 2, Name = "Сыр"},
                new ProductDto {Id = 3, Name = "Хлеб"},
                new ProductDto {Id = 4, Name = "Колбаса"}
            );

            modelBuilder.Entity<OrderDto>().HasData
            (
                new OrderDto {Id = 1, Status = OrderStatus.Complete, CreationTime = DateTime.Now.AddHours(-1)},
                new OrderDto {Id = 2, Status = OrderStatus.InProgress, CreationTime = DateTime.Now},
                new OrderDto {Id = 3, Status = OrderStatus.Complete, CreationTime = DateTime.Now.AddMinutes(-5)}
            );

            modelBuilder.Entity<OrderProductDto>().HasData
            (
                new OrderProductDto {Id = 1, OrderId = 1, ProductId = 2, Price = 500, Quantity = 1},
                new OrderProductDto {Id = 2, OrderId = 1, ProductId = 3, Price = 26.5M, Quantity = 3},
                new OrderProductDto {Id = 3, OrderId = 2, ProductId = 1, Price = 98, Quantity = 2},
                new OrderProductDto {Id = 4, OrderId = 2, ProductId = 4, Price = 358.99M, Quantity = 3},
                new OrderProductDto {Id = 5, OrderId = 3, ProductId = 1, Price = 500.99M, Quantity = 2}
            );
        }
    }
}