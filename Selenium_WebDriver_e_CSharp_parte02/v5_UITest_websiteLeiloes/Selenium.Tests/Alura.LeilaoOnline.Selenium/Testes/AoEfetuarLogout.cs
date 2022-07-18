using Xunit; // Namespace para uso da Collection
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
            // ARRANGE COM ESTILO LINGUAGEM FLUENTE (métodos encadeados)
            //
            new LoginPO(driver).Visitar().InformarEmail("fulano@example.org").InformarSenha("123").EfetuarLogin();

            var dashboardPO = new DashboardInteressadaPO(driver);

            //
            // ACT - efetuar logout
            //
            dashboardPO.Menu.EfetuarLogout();

            //
            // ASSERT
            //
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}