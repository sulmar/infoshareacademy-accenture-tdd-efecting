using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingConventions
{
    // Metody, zmienne, pola i właściwości logiczne powinny być prefiksowane is, can, has

    internal interface BooleanExamples
    {
        public bool IsValidNumber(int number);
        public bool IsAvailable();
        public bool IsActive();
        public bool IsEnabled();
        public bool IsOpen();
        public bool IsCompleted();
        public bool IsLoggedIn();
        public bool CanEdit();
        public bool IsEditable();
        public bool CanChangePassword();
        public bool HasPermission(string permission);
        public bool HasAnyOrder();
    }
}
