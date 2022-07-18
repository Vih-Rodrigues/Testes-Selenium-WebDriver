using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO; // Curso não ensina!
using System.Reflection; // Curso não ensina! - encontrei por https://docs.microsoft.com/pt-br/dotnet/api/system.reflection.assembly.getexecutingassembly?view=net-6.0

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //
            // 1º PASSO
            //
            // arrange - dado que um navegador está aberto
            // IWebDriver = Interface do Selenium pra representar uma nova janela de navegador
            // O objeto ChromeDriver recebe como parâmetro a pasta onde encontra-se o 'chromedriver.exe'
            // Path = API IO do .Net
            // GetDirectoryName = obtem nome da DLL gerada para esse projeto
            // Assembly.GetExecutingAssembly() = DLL gerada para esse projeto
            // Location = localização do arquivo 'chromedriver.exe'
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                );

            //
            // 2º PASSO
            //
            // act - quando navego para a URL htts://www.caelum.com.br
            // A variável 'driver' do tipo IWebDriver tem um método chamado 'Navigate', 
            // que possui um método chamado 'GoToUrl' que recebe como parâmetro uma URL em STRING
            driver.Navigate().GoToUrl("https://www.totvs.com/");

            //
            // 3º PASSO
            //
            // assert - então, esperado que a página apresentada seja da Caelum
            // -> Verificações de expectativa
            // O título do navegador (driver.Title) vai conter (Contains) a palavra "Caelum" 
            Assert.Contains("TOTVS", driver.Title);
        }
    }
}
