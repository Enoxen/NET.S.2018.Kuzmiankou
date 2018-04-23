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


        public PasswordCheckerService(IPasswordValidator validator, Action<string> action)
        {
            this.validator = validator ?? throw new ArgumentNullException($"{nameof(validator)} is null.");

            repoSave = action ?? throw new ArgumentNullException($"{nameof(action)} shold not be null.");
        }

        public Tuple<bool, string> VerifyPassword(string password, IEnumerable<IPasswordValidator> rules)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            foreach(var rule in rules)
            {
                if (!rule.ValidatePassword(password).Item1)
                {
                    return Tuple.Create(false, rule.GetErrorMessage());
                }  
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
