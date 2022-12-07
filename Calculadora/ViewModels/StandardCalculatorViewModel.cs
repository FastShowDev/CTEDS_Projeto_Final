using Calculadora.Commands;
using Calculadora.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Calculadora.Database;
using Microsoft.EntityFrameworkCore;
using Calculadora.Stores;
using System.ComponentModel;

namespace Calculadora.ViewModels
{
    public class StandardCalculatorViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Calculator calculator;
        public readonly Context context;
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
        public ICommand BackspaceCM { get; }
        public ICommand ClearDisplayCM { get; }
        public ICommand NumberClickCM { get; }
        public ICommand OperatorClickCM { get; }
        public ICommand CalculateCM { get; }
        public ICommand LoadHistoryCM { get; }
        #endregion


        public StandardCalculatorViewModel()
        {
            calculator = new Calculator();
            //CloseMenu = new CloseMenuCommand(this);
            //OpenMenu = new OpenMenuCommand(this);
            //NavigateMenuCM = new NavigateCommand();
            BackspaceCM = new BackspaceCommand(this);
            ClearDisplayCM = new ClearDisplayCommand(this);
            NumberClickCM = new NumberClickCommand(this);
            OperatorClickCM = new OperatorClickCommand(this);
            CalculateCM = new CalculateCommand(this);
            LoadHistoryCM = new LoadHistoryCommand(this);

            var contextOptions = new DbContextOptionsBuilder<Context>().UseSqlite("Data source = Histories.db").Options;
            context = new Context(contextOptions);

            histories = context.Histories.ToList();

            ViewName = "Padrão";
        }

        public void UpdateDisplay()
        {
            this.displayContent = calculator.displayContent;
            this.stringResult = calculator.result;
            calculator.hasCalculate = true;
        }


    }
}
