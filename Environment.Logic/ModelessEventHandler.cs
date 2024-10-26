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

        private readonly RotateFamiliesModel _model;

        public ModelessEventHandler(RotateFamiliesModel model, string name)
        {
            _model = model;
            this.name = name;
        }
        public void SetData(bool randomRotation, string rotationAngle, string rotationBase)
        {
            _rotationAngle = rotationAngle;
            _rotationBase = rotationBase;
            _randomRotation = randomRotation;
        }
        public void Execute(UIApplication app)
        {
            _model.RotateSelectedFamilies(_rotationAngle, _rotationBase, _randomRotation);
        }

        public string GetName()
        {
            return name;
        }
    }
}
