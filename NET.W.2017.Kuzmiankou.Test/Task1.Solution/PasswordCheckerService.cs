using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Task1.Solution
{

    class PasswordCheckerService
    {

        private readonly Action<string> repoSave;
        private readonly IPasswordValidator validator;


        public PasswordCheckerService(IPasswordValidator validator, Action<string> action)
        {
            this.validator = validator ?? throw new ArgumentNullException($"{nameof(validator)} is null.");

            repoSave = action ?? throw new ArgumentNullException($"{nameof(action)} shold not be null.");
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (validator.ValidatePassword(password))
            {
                repoSave.Invoke(password);
                return Tuple.Create(true, "Password is Ok. User was created");
            }
            else
            {
                return Tuple.Create(false, "Password must match constriants. Length: 7-15, at least one alphanumeric char, at least one digit.");
            }

            

            
        }
    }
}
