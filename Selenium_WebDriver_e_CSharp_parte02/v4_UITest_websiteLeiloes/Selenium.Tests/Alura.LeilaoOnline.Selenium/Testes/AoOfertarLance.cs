using Xunit; // Namespace para uso da coleção
using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe LoginPO
using OpenQA.Selenium.Support.UI; // Namespace para uso da classe WebDriverWait
using System; // Namespace para uso do TimeSpan

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")] // Indica que a classe AoOfertarLance está dentro da coleção Chrome Driver
    public class AoOfertarLance
    {
        // 
        // ATRIBUTOS PRIVADOS
        //
        private IWebDriver driver;

        //
        // CONSTRUTOR - INICIALIZA OS ATRIBUTOS
        //
        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        //
        // MÉTODO - TESTE
        //
        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //
            // ARRANGE
            //
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1); // Passado por parâmetro um leilão em andamento

            //
            // ACT 
            //
            detalhePO.OfertarLance(300);

            // 
            // ASSERT
            //

            // Método do Selenium para esperar a resposta da página 
            // espera explícita timeout 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            // Função que verifica se o lance atual é igual ao lance ofertado
            // Equanto a função não for TRUE, irá esperar o timeout
            // Ou após o timeout, a função retorna falso
            // Método Until recebe uma função IWebDriver que, a partir da expressão lambda, retorna um booleano
            bool iguais = wait.Until( driverArgumento => detalhePO.LanceAtual == 300 );
            Assert.True(iguais);  
        }
    }
}
