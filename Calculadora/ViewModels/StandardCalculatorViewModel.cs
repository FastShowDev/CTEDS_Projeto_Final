using Calculadora.Commands;
using Calculadora.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Calculadora.Database;
using Microsoft.EntityFrameworkCore;
using Calculadora.Stores;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Calculadora.Database.Managers;
using System.Threading.Tasks;

namespace Calculadora.ViewModels
{
    public class StandardCalculatorViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Calculator calculator;
        public HistoryManager historyManager;
        public readonly CalculatorDbContext context;
        public List<History> histories;

        #region Properties
        private string _displayContent = "0";
        public string displayContent
        {
            get { return _displayContent; }
            set
            {
                if (_displayContent != value)
                {
                    _displayContent = value;
                    OnPropertyChanged(nameof(displayContent));
                    calculator.displayContent = value;
                }
                return;
            }
        }

        private string _stringResult = "";
        public string stringResult
        {
            get { return _stringResult; }
            set
            {
                if (_stringResult != value)
                {
                    _stringResult = value;
                    OnPropertyChanged(nameof(stringResult));
                    calculator.result = value;
                }
                return;
            }
        }




        #endregion


        #region Commands
        //public new ICommand OpenMenu { get; }
        //public new ICommand CloseMenu { get; }
        //public ICommand NavigateMenuCM { get; }
        public ICommand OpenHistoryCM { get; }
        public ICommand BackspaceCM { get; }
        public ICommand ClearDisplayCM { get; }
        public ICommand NumberClickCM { get; }
        public ICommand OperatorClickCM { get; }
        public ICommand SquareClickCM { get; }
        public ICommand SqrtClickCM { get; }
        public ICommand CalculateCM { get; }
        public ICommand LoadHistoryCM { get; }
        #endregion


        public StandardCalculatorViewModel()
        {
            calculator = new Calculator();
            //CloseMenu = new CloseMenuCommand(this);
            //OpenMenu = new OpenMenuCommand(this);
            //NavigateMenuCM = new NavigateCommand();
            OpenHistoryCM = new OpenHistoryCommand(this);
            BackspaceCM = new BackspaceCommand(this);
            ClearDisplayCM = new ClearDisplayCommand(this);
            NumberClickCM = new NumberClickCommand(this);
            OperatorClickCM = new OperatorClickCommand(this);
            SquareClickCM = new SquareCommand(this);
            SqrtClickCM = new SquareRootCommand(this);
            CalculateCM = new CalculateCommand(this);
            LoadHistoryCM = new LoadHistoryCommand(this);

            var contextOptions = new DbContextOptionsBuilder<CalculatorDbContext>().UseSqlite("Data source = Histories.db").Options;
            context = new CalculatorDbContext(contextOptions);

            historyManager = new HistoryManager(context);

            ViewName = "Padrão";
        }


        public List<History> GetAllHistories()
        {
            Task<List<History>> histories = historyManager.GetAllHistories();
            histories.Result.Reverse();
            return histories.Result;
        }


        public void AddHistory(string expression, string result)
        {
            historyManager.AddHistory(new History(expression, result));
            return;
        }


        public void DeleteLastHistory()
        {
            historyManager.DeleteLastHistory();
            return;
        }


        public void UpdateDisplay()
        {
            this.displayContent = calculator.displayContent;
            this.stringResult = calculator.result;
            calculator.hasCalculate = true;
        }


    }
}
