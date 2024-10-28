using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment.Logic
{
    public class ModelessEventHandler : IExternalEventHandler
    {
        string name;
        private string _rotationAngle;
        private string _rotationBase;
        private bool _randomRotation;
        private bool _cancelOperation;

        private readonly RotateFamiliesModel _model;

        public ModelessEventHandler(RotateFamiliesModel model, string name)
        {
            _model = model;
            this.name = name;
        }
        public void SetData(bool randomRotation, string rotationAngle, string rotationBase, bool cancelOperation)
        {
            _rotationAngle = rotationAngle;
            _rotationBase = rotationBase;
            _randomRotation = randomRotation;
            _cancelOperation = cancelOperation;
        }
        public void Execute(UIApplication app)
        {
            _model.RotateSelectedFamilies(_rotationAngle, _rotationBase, _randomRotation, _cancelOperation);
        }

        public string GetName()
        {
            return name;
        }
    }
}
