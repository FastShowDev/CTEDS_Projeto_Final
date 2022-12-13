using Calculadora.Database;
using Calculadora.Database.Managers;
using Calculadora.ViewModels;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class LoadHistoryCommand : BaseAsyncCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public LoadHistoryCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _viewModel.historyManager.Load();
        }
    }
}
