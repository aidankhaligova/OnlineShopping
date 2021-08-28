using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Helpers
{
    public class UIMessages
    {
        public const string DeleteSureMessage = "Are you sure you want to delete?";
        public const string PhoneErrorMessage = "Telefon nömrəsi düzgün formatda deyil. Düzgün format: +99450XXXXXXX ";

        public const string ValidationCommonMessage = "Validation error";

        public const string OperationSuccessMessage = "Operation was completed successfully";

        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} must be entered";
        }

        public static string GetLengthMessage(string propName, int length)
        {
            return $"{propName} cannot be longer than {length} characters";
        }

        public static string GetNumberMessage(string propName, int value)
        {
            return $"{propName} cannot be greater than {value}";
        }
    }
}
