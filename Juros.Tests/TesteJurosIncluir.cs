using API.Juros.CommandHandlers.Handlers;
using API.Juros.MockSetup;
using AutoMapper;
using Domain.Commands;
using Domain.Mapper;
using Infra.Repositories;
using Infra.Repositories.CosmosDbMock;
using Moq;
using NUnit.Framework;

namespace Juros.Tests
{
    public class TesteJurosIncluir
    {
        private TaxaJurosCommandHandler _taxaJurosCommandHandler;
        private IMapper _mapper;
        private readonly ICosmosDbClientFactory _factory;


        [SetUp]
        public void Setup()
        {
            var configuration = new MapperConfiguration(_ => _.AddProfile(new InterestRateProfile()));
            
            _mapper = new Mapper(configuration);

            var mockSetup = new TaxaJurosMockSetup { Mocked = true };

            _taxaJurosCommandHandler = new TaxaJurosCommandHandler(_mapper, new TaxaJurosRepositoryMock(_factory), mockSetup);
        }

        [Test]
        public void IncluirSucesso()
        {
            var command = new InterestRateCommand
            {
                InterestRate = 1
            };

            var response = _taxaJurosCommandHandler.HandlerAsync(command).Result;

            Assert.IsNotEmpty(response.Mensagem);
            Assert.AreEqual(0.01, response.TaxaJuros);
        }
    }
}
