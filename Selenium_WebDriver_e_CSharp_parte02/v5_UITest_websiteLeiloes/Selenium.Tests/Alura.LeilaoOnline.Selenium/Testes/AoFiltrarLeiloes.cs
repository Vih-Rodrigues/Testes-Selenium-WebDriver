using Xunit; // Namespace para uso da classe Collection
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso das classes LoginPO e DashboardInteressadaPO
using System.Collections.Generic; // Namespace para uso da classe List

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")] // A classe AoFiltrarLeiloes está dentro da coleção Chrome Driver
    public class AoFiltrarLeiloes
    {
        // 
        // ATRIBUTOS PRIVADOS
        //
        private IWebDriver driver;

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        //
        // MÉTODO-TESTE
        //
        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelDeResultado()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);
            loginPO.EfetuarLoginComCredenciais("fulano@example.org", "123");

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //
            // ACT
            //
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(new List<string> { "Arte", "Coleções" }, "", true);

            //
            // ASSERT
            //
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }
    }
}
