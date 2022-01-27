using API.Juros.CommandHandlers.Handlers;
using API.Juros.MockSetup;
using API.Juros.QueryHandler.Handlers;
using AutoMapper;
using Domain.Commands;
using Domain.Mapper;
using Infra.Repositories;
using Infra.Repositories.CosmosDbMock;
using NUnit.Framework;

namespace Juros.Tests
{
    public class TesteJurosConsultar
    {
        private TaxaJurosQueryHandler _taxaJurosQueryHandler;
        private IMapper _mapper;
        private readonly ICosmosDbClientFactory _factory;


        [SetUp]
        public void Setup()
        {
            var configuration = new MapperConfiguration(_ => _.AddProfile(new InterestRateProfile()));
            
            _mapper = new Mapper(configuration);

            var mockSetup = new TaxaJurosMockSetup { Mocked = true };

            _taxaJurosQueryHandler = new TaxaJurosQueryHandler(_mapper, new TaxaJurosRepositoryMock(_factory), mockSetup);
        }

        [Test]
        public void ConsultarSucesso()
        {

            var response = _taxaJurosQueryHandler.HandlerAsync().Result;

            Assert.AreEqual("Sucesso", response.Mensagem);
            Assert.AreEqual(0.01, response.TaxaJuros);
        }
    }
}
