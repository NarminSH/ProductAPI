﻿namespace ProductAPI.Dtos.Products
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
