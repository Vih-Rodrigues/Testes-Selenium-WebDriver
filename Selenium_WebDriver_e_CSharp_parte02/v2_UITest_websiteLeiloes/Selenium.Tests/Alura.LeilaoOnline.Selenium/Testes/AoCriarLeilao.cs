using Xunit; // Namespace para uso da coleção
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe LoginPO
using System; // Namespace para uso do tipo DateTime
using System.Threading; // Namespace para uso da classe Thread

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")] // Indica que a classe AoCriarLeilao está dentro da coleção Chrome Driver
    public class AoCriarLeilao
    {
        // 
        // ATRIBUTOS PRIVADOS
        //
        private IWebDriver driver;

        //
        // CONSTRUTOR - INICIALIZA OS ATRIBUTOS
        //
        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        //
        // MÉTODO - TESTE
        //
        [Fact]
        public void DadoLoginAdministrativoEInfosValidasDeveCadastrarLeilao()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1", // Título
                "Descricao Teste Descricao Teste Descricao Teste Descricao Teste Descricao Teste", // Descrição
                "Item de Colecionador", // Categoria
                4000, // Valor inicial
                "C:\\imagensTeste\\colecao1.jpg", // Para passar valor para um campo InputFile, nesse caso a imagem, é necessário informar o valor absoluto do arquivo
                DateTime.Now.AddDays(20), // Inicio do Pregão será daqui 20 dias
                DateTime.Now.AddDays(40) // Término do Pregão será daqui 40 dias
            );

            // A classe Thread é um recurso que congela o teste durante um tempo determinado pelo parâmetro para que o testador verifique
            Thread.Sleep(20000);

            //
            // ACT
            //
            novoLeilaoPO.SubmeteFormulario();

            //
            // ASSERT
            //
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
