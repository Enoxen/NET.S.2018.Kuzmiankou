using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Task1.Solution
{

    class PasswordCheckerService
    {
        private readonly IRepository repoSave;

        public Tuple<bool, string> VerifyPassword(string password, IEnumerable<IPasswordValidator> rules)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            foreach(var rule in rules)
            {
                var tempRule = rule.ValidatePassword(password);
                if (tempRule.Item1)
                {
                    return Tuple.Create(false, tempRule.Item2);
                }  
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
