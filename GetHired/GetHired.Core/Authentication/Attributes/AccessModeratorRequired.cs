using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace GetHired.Core.Authentication.Attributes
{
    public class AccessModeratorRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Thread.CurrentPrincipal.IsInRole("Moderator");
        }
    }
}