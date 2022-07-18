using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using OpenQA.Selenium.Interactions; // Namespace para uso da Interface IAction

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        //
        // ATRIBUTO PRIVATIVO
        //
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink; // Atributo para capturar o link do ícone de perfil, que é um link cujo id no HTML é "meu-perfil"

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        //
        // MÉTODO - TESTE
        //
        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink); // Variável para capturar o id "meu-perfil" no código fonte da página
            var linkLogout = driver.FindElement(byLogoutLink); // Variável para capturar o id "logout" no código fonte da página

            // -------------------------------------------
            // Interface IAction do namespace Interactions
            // O objeto acaoLogout representa a ação completa (tudo que se deseja fazer)
            // Pra gerar o objeto que implementa essa interface com os três passos 
            // (mover o mouse para o ícone, mover para logout e clicar)
            // Se usa o padrão builder (objeto que é usado para criar outros objetos complexos) que é da classe Actions
            IAction acaoLogout = new Actions(driver)
                // Mover o mouse para o ícone de perfil - Usa-se o método MoveToElement, dentro de Actions
                .MoveToElement(linkMeuPerfil)
                // Mover o mouse para Logout
                .MoveToElement(linkLogout)
                // Clicar em "Logout"
                .Click()
                .Build(); // Build guarda a ação criada no objeto "acaoLogout"
            // -------------------------------------------

            acaoLogout.Perform(); // O método "Perform" faz a ação executar
        }
    }
}
