using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Calculadora.Commands.StatisticCommands;
using Calculadora.Models;

namespace Calculadora.ViewModels
{
    public class StatisticViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Properties
        public List<StatisticItem> items = new List<StatisticItem>();
        #endregion
        #region Commands
        public ICommand AddValueCM { get; }
        public ICommand CalculateStatisticCM { get; }
        public ICommand ResetCM { get; }
        #endregion
        public StatisticViewModel()
        {
            AddValueCM = new AddValueCommmand(this);
            CalculateStatisticCM = new CalculateStatisticCommand(this);
            ResetCM = new ResetCommand(this);

            ViewName = "Estatística";
            ViewHeight = 750;
            ViewWidth = 1000;
        }

        public void UpdateItemsId()
        {
            int i = 1;
            foreach(StatisticItem item in items)
            {
                item.id = i;
                i++;
            }
        }
    }
}
