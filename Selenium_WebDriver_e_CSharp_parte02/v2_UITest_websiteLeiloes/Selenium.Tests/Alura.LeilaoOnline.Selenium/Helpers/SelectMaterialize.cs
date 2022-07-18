using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using System.Collections.Generic; // Namespace para uso da classe IEnumerable
using System.Linq; // Namespace para uso da função ToList
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        //
        // ATRIBUTO PRIVATIVO
        //
        private IWebDriver driver;
        private IWebElement selectWrapper; // Atributo para guardar a estratégia de localização do select-wrapper
        private IEnumerable<IWebElement> opcoes;

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        //
        // MÉTODOS
        //

        // 1º Passo: Verificar as opções disponíveis dentro do wrapper
        // Ou seja, cria-se uma enumaração de IWebElements

        public IEnumerable<IWebElement> Opcoes => opcoes;

        private void OpenWrapper()
        {
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
        }

        // 2º Passo: Método para desmarcar todas as opções
        public void DeselectAll()
        {
            OpenWrapper();

            opcoes.ToList().ForEach(objeto => { objeto.Click(); });

            LoseFocus();

            // Pausa de 3 segundos
            Thread.Sleep(3000);
        }

        // 3º Passo: Verificar se a categoria que está sendo procurada corresponde a opção que está sendo lida
        // Se a opção corresponder à categoria, a mesma deve ser selecionada
        public void SelectByText(string opcao)
        {
            OpenWrapper();
            opcoes
                .Where(objeto => objeto.Text.Contains(opcao))
                .ToList()
                .ForEach(objeto => { objeto.Click(); });
            LoseFocus();

            // Pausa de 3 segundos
            Thread.Sleep(3000);
        }
    }
}
