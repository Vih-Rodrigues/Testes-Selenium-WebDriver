using System; // Namespace para uso da interface IDisposable e da excessão NotImplementedException
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Chrome; // Namespace para uso da classe ChromeDriver
using Alura.LeilaoOnline.Selenium.Helpers; // Namespace para uso da classe TestHelper
using Xunit; // Namespace para uso do atributo "Fact"
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe HomeNaoLogadaPO

namespace Alura.LeilaoOnline.Selenium.Testes
{
    // Construtor e Dispose utilizados para compartilhar o driver com todos os testes dessa mesma classe
    public class AoNavegarParaHomeMobile : IDisposable // Esse teste implementa a interface IDisposable
    {
        // 
        // ATRIBUTOS PRIVADOS
        //
        private ChromeDriver driver;

        //
        // CONSTRUTOR - INICIALIZA OS ATRIBUTOS
        //
        public AoNavegarParaHomeMobile()
        { 
        }

        //
        // MÉTODOS - TESTES
        //
        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //
            // ARRANGE
            //
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 992; // Altura
            deviceSettings.Height = 800; // Largura
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings); // Método para "habilitar a simulação de dispositivo móvel"

            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);

            var homePO = new HomeNaoLogadaPO(driver);

            //
            // ACT
            //
            homePO.Visitar();

            //
            // ASSERT
            //
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //
            // ARRANGE
            //
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 993; // Altura
            deviceSettings.Height = 800; // Largura
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings); // Método para "habilitar a simulação de dispositivo móvel"

            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);

            var homePO = new HomeNaoLogadaPO(driver);

            //
            // ACT
            //
            homePO.Visitar();

            //
            // ASSERT
            //
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }

        //
        // MÉTODO DISPOSE
        //
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
