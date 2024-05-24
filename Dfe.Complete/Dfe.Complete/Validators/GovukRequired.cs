using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Validators
{
    public class GovukRequired : RequiredAttribute
    {
        public GovukRequired()
        {
            ErrorMessage = "Enter {0}";
        }
    }
}
