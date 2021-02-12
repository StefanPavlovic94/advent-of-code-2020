using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4
{
    public class PasswordPolicy : IPasswordPolicy
    {
        private readonly IEnumerable<string> requiredFields;

        public PasswordPolicy(IEnumerable<string> requiredFields)
        {
            this.requiredFields = requiredFields;
        }

        //public bool IsValidPassword(IEnumerable<PassportField> fields)
        //    => requiredFields.All(requiredField => fields.Any(field => field.Key == requiredField));

        public bool IsValidPassword(IEnumerable<PassportField> fields)
        {
            return requiredFields.All(requiredField => fields.Any(field => field.Key == requiredField)) && fields.All(f => ValidateField(f));
        }

        private bool ValidateField(PassportField field)
        {
            var eyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            switch (field.Key)
            {
                case PassportBuilder.BirthYear:
                    return int.TryParse(field.Value, out int value) && value >= 1920 && value <= 2002;
                case PassportBuilder.ExpirationYear:
                    return int.TryParse(field.Value, out int value1) && value1 >= 2020 && value1 <= 2030;
                case PassportBuilder.EyeColor:
                    return eyeColors.Contains(field.Value);
                case PassportBuilder.IssueYear:
                    return int.TryParse(field.Value, out int value2) && value2 >= 2010 && value2 <= 2020;
                case PassportBuilder.HairColor: return ValidHairColor(field.Value);
                case PassportBuilder.Height: return ValidHeight(field.Value);
                case PassportBuilder.PassportId: return ValidPassportId(field.Value);
                default:
                    break;
            }

            return true;
        }

        private bool ValidHeight(string height)
        {
            if (string.IsNullOrWhiteSpace(height)) return false;

            var regex = new Regex(@"^\d{1,3}(cm|in)$");

            if (!regex.IsMatch(height)) return false;

            var number = int.Parse(Regex.Match(height, @"^\d{1,3}").Value);
            var unit = Regex.Match(height, @"(cm|in)").Value;

            if (unit == "cm" && (number < 150 || number > 193)) return false;
            if (unit == "in" && (number < 59 || number > 76)) return false;

            return true;
        }

        private bool ValidPassportId(string passportId) 
        {
            if (string.IsNullOrWhiteSpace(passportId)) return false;
            return Regex.IsMatch(passportId, @"^\d{9}$");
        }

        private bool ValidHairColor(string hairColor) 
        {
            if (string.IsNullOrWhiteSpace(hairColor)) return false;

            return Regex.IsMatch(hairColor, @"^#[0-9a-fA-F]{6}$");
        }
    }
}
