using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DevReviews.API.Models.ProductDetailsViewModel;

namespace DevReviews.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductReview, ProductReviewViewModel>();
            CreateMap<ProductReview, ProductReviewDetailsViewModel>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDetailsViewModel>();
        }
    }
}
