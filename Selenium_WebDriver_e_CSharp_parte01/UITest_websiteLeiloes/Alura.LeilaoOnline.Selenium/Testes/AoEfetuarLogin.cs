using Xunit; // Namespace para uso da classe Collection
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe LoginPO

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        //
        // ATRIBUTO PRIVATIVO
        //
        private IWebDriver driver;

        //
        // CONSTRUTOR
        //
        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        //
        // 1º MÉTODO - TESTE
        //
        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);

            // Chamada do método para navegar para a URL do site
            loginPO.Visitar();

            // Passando credenciais válidas:
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //
            // ACT
            //
            loginPO.SubmeteFormulario();

            //
            // ASSERT
            //
            Assert.Contains("Dashboard", driver.Title);
        }

        //
        // 2º MÉTODO - TESTE
        //
        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);

            // Chamada do método para navegar para a URL do site
            loginPO.Visitar();

            // Passando credenciais inválidas:
            loginPO.PreencheFormulario("fulano@example.org", "");

            //
            // ACT
            //
            loginPO.SubmeteFormulario();

            //
            // ASSERT
            //
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
