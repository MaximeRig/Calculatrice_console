using System.Globalization;
using System;

namespace Calculatrice {
    class Program {
        private static string _questionForNumber = "Veuillez saisir un nombre : ";
        private static string[] _operationList = new string[4] { "a", "s", "m", "d" };
        private static string? _inputOperation;
        private static decimal _result = 0;
        private static decimal _num1;
        private static decimal _num2;

        static void Main() {
            Console.WriteLine("Bienvenue sur ma première application en C#: une calculatrice.");

            _num1 = GetNumber();

            AskForOperation();

            _inputOperation = GetOperation();

            _num2 = GetNumber();
                
            Calculate(_inputOperation);

            ShowResult();
        }

        static string GetOperation() {
            string? input = Console.ReadLine();
            while (!Array.Exists(_operationList, el => el == input)) {
                AskForOperation();
                input = Console.ReadLine();
            }

            return input;
        }

        static void Calculate(string operation) {
            switch (operation) {
                case "a":
                    _result = _num1 + _num2;
                    break;
                case "s":
                    _result = _num1 - _num2;
                    break;
                case "m":
                    _result = _num1 * _num2;
                    break;
                case "d":
                    while (_num2 == 0) {
                        Console.WriteLine("Vous ne pouvez pas diviser par 0, veuillez choisir un autre nombre.");
                        string? input2 = Console.ReadLine();
                        while (!IsInputParsed(input2)) {
                            Console.WriteLine(_questionForNumber);
                            input2 = Console.ReadLine();
                        }
                        _num2 = Convert.ToDecimal(input2);
                    }
                    _result = _num1 / _num2;
                    break;
            }
        }

        static void ShowResult() {
            Console.WriteLine($"Résultat = {_result}");
        }

        static decimal GetNumber() {
            Console.WriteLine(_questionForNumber);
            string? input = Console.ReadLine();
            while (!IsInputParsed(input)) {
                Console.WriteLine(_questionForNumber);
                input = Console.ReadLine();
            }

            return Convert.ToDecimal(input);
        }

        static void AskForOperation() {
            Console.WriteLine("Veuillez choisir une opération :");
            Console.WriteLine("\ttaper a pour faire une addition");
            Console.WriteLine("\ttaper s pour faire une soustraction");
            Console.WriteLine("\ttaper m pour faire une multiplication");
            Console.WriteLine("\ttaper d pour faire une division");
        }

        static bool IsInputParsed(string input) {
            return Decimal.TryParse(input, NumberStyles.Any, new CultureInfo("fr-FR"), out decimal result);
        }
    }
}