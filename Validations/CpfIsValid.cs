using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CpfIsValidAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
            return ValidationResult.Success;

        string cpf = value.ToString().Trim();

        if (cpf.Length != 11 || Regex.IsMatch(cpf, @"^(\d)\1{10}$"))
        {
            return new ValidationResult("O CPF deve conter exatamente 11 dígitos numéricos.");
        }

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (!IsCpfValid(cpf))
        {
            return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }

    private bool IsCpfValid(string cpf)
    {
        int sum = 0;
        int remainder;

        for (int i = 0; i < 9; i++)
        {
            sum += (cpf[i] - '0') * (10 - i);
        }

        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        if (remainder != (cpf[9] - '0'))
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += (cpf[i] - '0') * (11 - i);
        }

        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        if (remainder != (cpf[10] - '0'))
            return false;

        return true;
    }
}