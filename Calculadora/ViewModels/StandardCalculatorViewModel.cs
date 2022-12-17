using Calculadora.Commands;
using Calculadora.Models;
using System.Collections.Generic;
using System.Windows.Input;
using Calculadora.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Calculadora.Database.Managers;
using System.Threading.Tasks;
using System;

namespace Calculadora.ViewModels
{
    public class StandardCalculatorViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public HistoryManager historyManager;
        private readonly CalculatorDbContext context;

        #region Properties
        private string _displayContent = "0";
        public string DisplayContent
        {
            get { return _displayContent; }
            set
            {
                if (_displayContent != value)
                {
                    _displayContent = value;
                    OnPropertyChanged(nameof(DisplayContent));
                    CalculatorDisplay.DisplayContent = value;
                }
                return;
            }
        }

        private string _stringResult = string.Empty;
        public string StringResult
        {
            get { return _stringResult; }
            set
            {
                if (_stringResult != value)
                {
                    _stringResult = value;
                    OnPropertyChanged(nameof(StringResult));
                    CalculatorDisplay.Result = value;
                }
                return;
            }
        }
        

        #endregion


        #region Commands
        public ICommand OpenHistoryCM { get; }
        public ICommand DeleteHistoryCM { get; }

        public ICommand BackspaceCM { get; }
        public ICommand ClearDisplayCM { get; }

        public ICommand NumberClickCM { get; }
        public ICommand OperatorClickCM { get; }
        public ICommand PercentageClickCM { get; }

        public ICommand InversionClickCM { get; }
        public ICommand SquareClickCM { get; }
        public ICommand SqrtClickCM { get; }

        public ICommand CalculateCM { get; }
        public ICommand LoadHistoryCM { get; }
        #endregion

        public StandardCalculatorViewModel()
        {
            DbContextOptions<CalculatorDbContext> contextOptions = new DbContextOptionsBuilder<CalculatorDbContext>().UseSqlite("Data source = Histories.db").Options;
            context = new CalculatorDbContext(contextOptions);
            historyManager = new HistoryManager(context);

            OpenHistoryCM = new OpenHistoryCommand(this);
            DeleteHistoryCM = new DeleteHistoryCommand(this);

            BackspaceCM = new BackspaceCommand(this);
            ClearDisplayCM = new ClearDisplayCommand(this);

            NumberClickCM = new NumberClickCommand(this);
            OperatorClickCM = new OperatorClickCommand(this);
            PercentageClickCM = new PercentageCommand(this);

            InversionClickCM = new InversionCommand(this);
            SquareClickCM = new SquareCommand(this);
            SqrtClickCM = new SquareRootCommand(this);

            CalculateCM = new CalculateCommand(this);
            LoadHistoryCM = new LoadHistoryCommand(this);

            ViewName = "Padrão";
        }


        public List<History> GetAllHistories()
        {
            Task<List<History>> histories = historyManager.GetAllHistories();
            histories.Result.Reverse();
            return histories.Result;
        }


        public async void AddHistory(string expression, string result)
        {
            await historyManager.AddHistory(new History(expression, result));
            return;
        }


        public void DeleteFirstHistory()
        {
            historyManager.DeleteFirstHistory();
            return;
        }


        public void DeleteAllHistory()
        {
            historyManager.DeleteAllHistory();
            return;
        }


        public void MaintainHistory()
        {
            historyManager.MaintainHistory();
            return;
        }


        public void UpdateDisplay()
        {
            this.DisplayContent = CalculatorDisplay.DisplayContent;
            this.StringResult = CalculatorDisplay.Result;
            this.HasErrorMessage = CalculatorDisplay.HasErrorMessage;
        }


        public static StandardCalculatorViewModel LoadViewModel()
        {
            StandardCalculatorViewModel newViewModel = new StandardCalculatorViewModel();
            newViewModel.LoadHistoryCM.Execute(null);
            return newViewModel;
        }


    }
}
