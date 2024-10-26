using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Environment.Logic;
using System.Windows.Input;
using Autodesk.Revit.UI;

namespace Environment.Windows
{
    /// <summary>
    /// View model for command "Checker"
    /// </summary>
    public class RotateFamiliesViewModel : BaseViewModel
    {
        #region FIELDS

        private RotateFamiliesModel _rotateFamiliesModel;
        private ExternalEvent _externalEvent;
        private ModelessEventHandler _eventHandler;

        #endregion

        #region PROPERTIES

        private string itemsSelectedCount;

        public string ItemsSelectedCount
        {
            get { return itemsSelectedCount; }
            set { itemsSelectedCount = value; }
        }

        private bool inputCorrect;

        public bool InputCorrect
        {
            get { return inputCorrect; }
            set 
            { 
                inputCorrect = value; 
                OnPropertyChanged(nameof(InputCorrect));
            }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set 
            { 
                error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        private bool randomRotation;
        public bool RandomRotation
        {
            get { return randomRotation; }
            set 
            { 
                randomRotation = value;
                OnPropertyChanged(nameof(RandomRotation));
            }
        }

        private string angle;

        public string Angle
        {
            get { return angle; }
            set 
            { 
                angle = value; 
                OnPropertyChanged(nameof(Angle));
                CheckInput();
            }
        }

        public List<string> RotationPointOptions => new List<string>()
        {
            "Base Point",
            "Centre of Bounding Box"
        };

        private string selectedRotationOption;

        public string SelectedRotationOption
        {
            get { return selectedRotationOption; }
            set 
            { 
                selectedRotationOption = value; 
                OnPropertyChanged(nameof(SelectedRotationOption));
            }
        }

        #endregion

        #region CONSTRUCTOR
        public RotateFamiliesViewModel(RotateFamiliesModel rotateFamiliesModel, ExternalEvent externalEvent, ModelessEventHandler eventHandler, int count)
        {
            _eventHandler = eventHandler;
            _externalEvent = externalEvent;
            _rotateFamiliesModel = rotateFamiliesModel;
            ItemsSelectedCount = count.ToString();
            SelectedRotationOption = RotationPointOptions.First();
            Angle = "15";
            InputCorrect = true;

            RunCommand = new CommandWindow(RunAction);
            CloseCommand = new CommandWindow(CloseAction);
            ApplyCommand = new CommandGeneric(ApplyAction);
        }

        #endregion

        #region VALIDATION

        private void CheckInput()
        {
            bool success = double.TryParse(Angle, out double parsedAngle);

            if (!success)
            {
                InputCorrect = false;
                Error = "Inconsistent Units";
            }
            else
            {
                InputCorrect = true;
                Error = "";
            }
        }
        #endregion

        #region COMMANDS

        public ICommand ApplyCommand { get; set; }

        private protected override void RunAction(Window window)
        {
            _eventHandler.SetData(RandomRotation, Angle, SelectedRotationOption);
            _externalEvent.Raise();

            CloseAction(window);
        }

        private void ApplyAction()
        {
            _eventHandler.SetData(RandomRotation, Angle, SelectedRotationOption);
            _externalEvent.Raise();
        }

        private protected override void CloseAction(Window window)
        {
            if (window != null)
            {
                Closed = true;
                window.Close();
            }
        }
        #endregion
    }
}