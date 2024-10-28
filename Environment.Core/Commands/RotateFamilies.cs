using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Environment.Logic;
using Environment.Windows;
using System.Windows;

namespace Environment.Core
{
    [Transaction(TransactionMode.Manual)]
    public class RotateFamilies : IExternalCommand
    {
        private protected string _transactionName;
        private protected BaseViewModel _viewModel;
        private protected Window _view;
        private protected RunResult _result;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication app = commandData.Application;
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            RotateFamiliesModel model = new RotateFamiliesModel(uidoc, app);

            int count = model.SelectFamilyInstances();

            if (count == 0)
                return Result.Failed;

            ModelessEventHandler eventHandler = new ModelessEventHandler(model, "");
            ExternalEvent externalEvent = ExternalEvent.Create(eventHandler);

            RotateFamiliesViewModel viewModel = new RotateFamiliesViewModel(model, externalEvent, eventHandler, count);
            RotateFamiliesForm window = new RotateFamiliesForm
            {
                DataContext = viewModel
            };
            window.Show();

            return Result.Succeeded;
        }

        public static string GetPath() => typeof(RotateFamilies).Namespace + "." + nameof(RotateFamilies);
    }
}