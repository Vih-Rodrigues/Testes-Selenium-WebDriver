using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using System.Collections.Generic; // Namespace para uso da classe List
using Alura.LeilaoOnline.Selenium.Helpers; // Namespace para uso das classes SelectMaterialize e TestHelper

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        //
        // ATRIBUTOS PRIVATIVOS
        //
        private IWebDriver driver;
        private By bySelectCategorias; // Localizador para capturar a região que tem o filtro de leilões
        private By byInputTermo; // Localizador do input do termo de pesquisa
        private By byInputAndamento; // Localizador para o input que busca saber se está em andamento
        private By byBotaoPesquisar; // Atributo para capturar o link do botão Pesquisar

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn"); // button é filho direto de form, e a classe é btn
        }

        //
        // MÉTODO
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
    }
}