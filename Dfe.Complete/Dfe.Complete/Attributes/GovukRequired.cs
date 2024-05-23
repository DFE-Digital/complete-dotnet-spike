using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Attributes
{
    public class GovukRequired : RequiredAttribute
    {
        public GovukRequired()
        {
            ErrorMessage = "Enter {0}";
        }
    }
}
