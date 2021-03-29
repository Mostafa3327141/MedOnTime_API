using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.CaretakerNameSpace
{
    public interface ICaretakerServices
    {
        List<Caretaker> GetCaretakers();
        Caretaker GetCaretaker(string id);

        Caretaker AddCaretaker(Caretaker caretaker);

        void DeleteCaretaker(string id);

        Caretaker UpdateCaretaker(Caretaker caretaker);
    }
}
