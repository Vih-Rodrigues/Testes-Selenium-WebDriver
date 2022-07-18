using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO; // Curso n�o ensina!
using System.Reflection; // Curso n�o ensina! - encontrei por https://docs.microsoft.com/pt-br/dotnet/api/system.reflection.assembly.getexecutingassembly?view=net-6.0

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //
            // 1� PASSO
            //
            // arrange - dado que um navegador est� aberto
            // IWebDriver = Interface do Selenium pra representar uma nova janela de navegador
            // O objeto ChromeDriver recebe como par�metro a pasta onde encontra-se o 'chromedriver.exe'
            // Path = API IO do .Net
            // GetDirectoryName = obtem nome da DLL gerada para esse projeto
            // Assembly.GetExecutingAssembly() = DLL gerada para esse projeto
            // Location = localiza��o do arquivo 'chromedriver.exe'
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                );

            //
            // 2� PASSO
            //
            // act - quando navego para a URL htts://www.caelum.com.br
            // A vari�vel 'driver' do tipo IWebDriver tem um m�todo chamado 'Navigate', 
            // que possui um m�todo chamado 'GoToUrl' que recebe como par�metro uma URL em STRING
            driver.Navigate().GoToUrl("https://www.totvs.com/");

            //
            // 3� PASSO
            //
            // assert - ent�o, esperado que a p�gina apresentada seja da Caelum
            // -> Verifica��es de expectativa
            // O t�tulo do navegador (driver.Title) vai conter (Contains) a palavra "Caelum" 
            Assert.Contains("TOTVS", driver.Title);
        }
    }
}
