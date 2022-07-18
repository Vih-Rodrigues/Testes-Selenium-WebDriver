using OpenQA.Selenium; // Namespace para uso da classe IWebDriver

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        //
        // ATRIBUTOS PRIVATIVOS
        //
        private IWebDriver driver;

        //
        // PROPRIEDADES AUTOIMPLEMENTADAS PÚBLICAS
        //
        public FiltroLeiloesPO Filtro { get; private set; }
        public MenuLogadoPO Menu { get; private set; }

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }
    }
}
