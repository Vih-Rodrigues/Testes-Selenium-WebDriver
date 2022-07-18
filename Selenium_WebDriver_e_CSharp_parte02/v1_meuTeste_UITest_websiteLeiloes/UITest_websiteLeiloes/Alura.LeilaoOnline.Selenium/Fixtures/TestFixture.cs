//
// Classe para criar o driver e limpá-lo (SETUP e TEARDOWN)
//

using OpenQA.Selenium; // Biblioteca para uso da interface do Selenium IWebDriver (pra representar uma nova janela de navegador)
using OpenQA.Selenium.Chrome; // Biblioteca para uso da classe ChromeDriver
using Alura.LeilaoOnline.Selenium.Helpers; // Biblioteca para uso do método PastaDoExecutavel
using System; // Biblioteca para uso da interface IDisposable

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //
        // CONSTRUTOR => SETUP
        //
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        //
        // TearDown = prática - Liberar recursos quando o teste terminar
        // não existe uma notação para essa prática, portanto se usa a interface IDisposable
        //
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
