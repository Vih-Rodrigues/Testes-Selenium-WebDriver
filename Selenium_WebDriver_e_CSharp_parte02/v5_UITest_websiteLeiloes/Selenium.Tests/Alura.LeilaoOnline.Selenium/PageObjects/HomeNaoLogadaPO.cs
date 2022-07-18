using OpenQA.Selenium; // Namespace para uso da classe IWebDriver

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomeNaoLogadaPO
    {
        // 
        // ATRIBUTOS PRIVATIVOS - LOCALIZADORES
        //
        private IWebDriver driver;

        // 
        // PROPRIEDADE AUTOIMPLEMENTADA
        //
        public MenuNaoLogadoPO Menu { get; set; }


        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        // 
        public HomeNaoLogadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Menu = new MenuNaoLogadoPO(driver);
        }

        //
        // MÉTODOS
        //
        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }
    }
}
