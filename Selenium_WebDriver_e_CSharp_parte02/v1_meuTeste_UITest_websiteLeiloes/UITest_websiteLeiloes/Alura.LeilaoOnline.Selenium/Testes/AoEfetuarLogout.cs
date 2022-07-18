﻿using Xunit; // Namespace para uso da Collection
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe LoginPO

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")] // Para compartihar o contexto da fixture da TestFixture, se indica que a classe AoEfetuarLogout está dentro da coleção Chrome Driver
    public class AoEfetuarLogout
    {
        //
        // ATRIBUTO PRIVATIVO
        //
        private IWebDriver driver;

        // 
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        // 
        public AoEfetuarLogout(TestFixture fixture) // TestFixture fixture compartilha o contexto desse teste
        {
            driver = fixture.Driver; // Guarda o driver que está na fixture
        }

        //
        // MÉTODO - TESTE
        //
        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(driver);

            //
            // ACT - efetuar logout
            //
            dashboardPO.EfetuarLogout();

            //
            // ASSERT
            //
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}