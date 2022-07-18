using Xunit; // Namespace para uso da coleção
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso das classes LoginPO e NovoLeilaoPO
using System.Linq; // Namespace para uso do Count

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")] // Indica que a classe AoCriarLeilao está dentro da coleção Chrome Driver
    public class AoNavegarParaFormNovoLeilao
    {
        // 
        // ATRIBUTOS PRIVADOS
        //
        private IWebDriver driver;

        //
        // CONSTRUTOR - INICIALIZA OS ATRIBUTOS
        //
        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        //
        // 1º MÉTODO - TESTE
        //
        [Fact]
        public void DadoLoginAdministrativoDeveMostrarTresCategorias()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);

            //
            // ACT
            //
            novoLeilaoPO.Visitar();

            //
            // ASSERT
            //
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
