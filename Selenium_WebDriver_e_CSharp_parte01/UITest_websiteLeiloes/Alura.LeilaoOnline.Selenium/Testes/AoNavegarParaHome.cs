/*
P�gina com API da interface IWebElement: 
https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_IWebElement.htm 

P�gina com API da classe By:
https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_By.htm

* propriedade Displayed indica que o elemento est� sendo exibido
* propriedade Text possui o texto dentro do elemento
* novas estrat�gias de localiza��o atrav�s dos m�todos est�ticos CssSelector() e TagName()
* o m�todo FindElements() retorna uma cole��o de elementos
* IWebElement tamb�m possui os m�todos FindElement() ou FindElements() e podem ser usados para encontrar elementos filhos
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
        // Setup = pr�tica - inicializar testes atrav�s do setup
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
            Assert.Contains("Leil�es", driver.Title);
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
            // Busca "Pr�ximos Leil�es" no c�digo fonte da p�gina
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
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
            // Busca o formul�rio
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            // Pra cada span dentro da cole��o de spans...
            foreach (var span in spans)
            {
                // Verifica se o texto que est� dentro da tag span � vazio
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
