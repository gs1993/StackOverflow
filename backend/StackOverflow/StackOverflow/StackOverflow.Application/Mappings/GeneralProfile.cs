using AutoMapper;
using StackOverflow.Application.Features.Products.Commands.CreateProduct;
using StackOverflow.Application.Features.Products.Queries.GetAllProducts;
using StackOverflow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
