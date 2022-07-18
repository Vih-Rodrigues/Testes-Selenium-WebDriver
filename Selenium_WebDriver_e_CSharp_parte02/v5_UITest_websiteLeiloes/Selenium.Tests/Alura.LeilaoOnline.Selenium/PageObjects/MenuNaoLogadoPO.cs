using OpenQA.Selenium; // Namespace para uso da classe IWebDriver

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        //
        // ATRIBUTOS PRIVATIVOS
        //
        private IWebDriver driver;
        private By byMenuMobile;

        //
        // PROPRIEDADE AUTOIMPLEMENTADA
        //
        public bool MenuMobileVisivel 
        { 
            get
            {
                var elemento = driver.FindElement(byMenuMobile);
                return elemento.Displayed;
            }
        }

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public MenuNaoLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byMenuMobile = By.ClassName("sidenav-trigger"); // Busca pelo nome da classe 
        }
    }
}
