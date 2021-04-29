using AutoMapper;
using Grpc.Core;
using Shop.Interfaces;
using Shop.Protos;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ServicesGrpc
{
    public class ProductService : Product.ProductBase
    {
        private IRepository<Models.Product> _repository;
        private IMapper _mapper;

        public ProductService(IRepository<Models.Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Task<ResponseProduct> SendProduct(RequestProduct request, ServerCallContext context)
        {
            Models.Product p = _mapper.Map<Models.Product>(request);
            _repository.Create(p);
            return Task.FromResult( new ResponseProduct { Message = "Product added with id "+p.Id});
        }
    }
}
