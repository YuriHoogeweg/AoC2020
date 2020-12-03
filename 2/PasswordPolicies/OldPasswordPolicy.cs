using System.Text.RegularExpressions;

namespace _2.PasswordPolicies
{
    public class OldPasswordPolicy
    {
        public char Character { get; set; }
        public int RepetitionsMin { get; set; }
        public int RepetitionsMax { get; set; }

        public OldPasswordPolicy(string passwordLine)
        {
            var match = new Regex(@"(\d*)-(\d*)\s([a-zA-Z]):").Matches(passwordLine)[0];

            RepetitionsMin = int.Parse(match.Groups[1].Value);
            RepetitionsMax = int.Parse(match.Groups[2].Value);
            Character = match.Groups[3].Value[0];
        }
    }
}
