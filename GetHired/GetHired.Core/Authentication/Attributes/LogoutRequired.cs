using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace GetHired.Core.Authentication.Attributes
{
    public class LogoutRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Thread.CurrentPrincipal == null;
        }
    }
}