using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using OpenQA.Selenium.Interactions; // Namespace para uso da Interface IAction
using System.Collections.Generic; // Namespace para uso da classe List
using Alura.LeilaoOnline.Selenium.Helpers; // Namespace para uso das classes SelectMaterialize e TestHelper

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
        private By bySelectCategorias; // Localizador para capturar a região que tem o filtro de leilões
        private By byInputTermo; // Localizador do input do termo de pesquisa
        private By byInputAndamento; // Localizador para o input que busca saber se está em andamento
        private By byBotaoPesquisar; // Atributo para capturar o link do botão Pesquisar

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn"); // button é filho direto de form, e a classe é btn
        }

        //
        // MÉTODOS
        //
        
        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            // 1º Passo: Encontrar o select-wrapper
            var select = new SelectMaterialize(driver, bySelectCategorias);

            // 2º Passo: Desmarcar todas as opções
            select.DeselectAll();

            // 3º Passo: Verificar as categorias selecionadas
            categorias.ForEach(categoria =>
            {
                select.SelectByText(categoria);
            });

            // 4º Passo: Setar o termo
            driver.FindElement(byInputTermo).SendKeys(termo);
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click(); // Se estiver em andamento, o checkbox será marcado
            }

            driver.FindElement(byBotaoPesquisar).Click();
        }

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
