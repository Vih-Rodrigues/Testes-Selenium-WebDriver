/*
Página com API da interface IWebElement: 
https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_IWebElement.htm 

Página com API da classe By:
https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_By.htm

* propriedade Displayed indica que o elemento está sendo exibido
* propriedade Text possui o texto dentro do elemento
* novas estratégias de localização através dos métodos estáticos CssSelector() e TagName()
* o método FindElements() retorna uma coleção de elementos
* IWebElement também possui os métodos FindElement() ou FindElements() e podem ser usados para encontrar elementos filhos
*/

using Xunit;
using OpenQA.Selenium; // Biblioteca para uso da interface do Selenium IWebDriver (pra representar uma nova janela de navegador)
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace importado para uso

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;
        
        //
        // Setup = prática - inicializar testes através do setup
        //
        // CONSTRUTOR
        public AoNavegarParaHome(TestFixture fixture)
        {
            //
            // ARRANGE
            //
            driver = fixture.Driver;
        }

        //
        // CLASSE PRINCIPAL TESTES
        //
        //
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //
            // ACT
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            // 
            // ASSERT
            //
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //
            // ACT
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            // 
            // ASSERT
            //
            // Busca "Próximos Leilões" no código fonte da página
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //
            // ACT
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            // 
            // ASSERT
            //
            // Busca o formulário
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            // Pra cada span dentro da coleção de spans...
            foreach (var span in spans)
            {
                // Verifica se o texto que está dentro da tag span é vazio
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
