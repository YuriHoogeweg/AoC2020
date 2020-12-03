using System.Text.RegularExpressions;

namespace _2.PasswordPolicies
{
    public class CurrentPasswordPolicy
    {
        public char Character { get; set; }
        public int Index1 { get; set; }
        public int Index2 { get; set; }

        public CurrentPasswordPolicy(string passwordLine)
        {
            var match = new Regex(@"(\d*)-(\d*)\s([a-zA-Z]):").Matches(passwordLine)[0];

            Index1 = int.Parse(match.Groups[1].Value);
            Index2 = int.Parse(match.Groups[2].Value);
            Character = match.Groups[3].Value[0];
        }
    }
}
