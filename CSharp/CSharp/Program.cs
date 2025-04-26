using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz zadanie");

            Console.WriteLine("Zadanie 1: Prosty kalkulator dwóch liczb");
            Console.WriteLine("Zadanie 2: Konwerter temperatur (Celsjusz <-> Fahrenheit)");
            Console.WriteLine("Zadanie 3: Średnia ocen ucznia");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Calculator();
                    break;
                case 2:
                    TemperatureConverter();
                    break;
                case 3:
                    StudentGrades();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór");
                    break;
            }

        }

        static void Calculator()
        {
            Console.WriteLine("Podaj dwie liczby i operację, oddzielone ', ' (np. 10, 20, +):");
            string input = Console.ReadLine();

            // Ustawienie kultury, aby kropka była separatorem dziesiętnym przy parsowaniu
            CultureInfo culture = CultureInfo.InvariantCulture;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Błąd: Nie podano danych wejściowych.");
                return;
            }

            // Podział wejścia na części
            string[] parts = input.Split(new[] { ", " }, StringSplitOptions.None);

            // Sprawdzenie, czy mamy dokładnie 3 części
            if (parts.Length != 3)
            {
                Console.WriteLine("Błąd: Niepoprawny format wejścia. Oczekiwano formatu: liczba1, liczba2, operacja");
                return;
            }

            try
            {
                // Parsowanie liczb (używamy Trim() do usunięcia ewentualnych białych znaków)
                double num1 = double.Parse(parts[0].Trim(), culture);
                double num2 = double.Parse(parts[1].Trim(), culture);

                // Pobranie operacji (również usuwamy białe znaki)
                string opStr = parts[2].Trim();
                if (opStr.Length != 1)
                {
                    Console.WriteLine("Błąd: Niepoprawny operator. Oczekiwano pojedynczego znaku (+, -, *, /).");
                    return;
                }
                char op = opStr[0];

                double result = 0;
                bool isValidOperation = true;

                // Wykonanie obliczeń
                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Błąd: Nie można dzielić przez zero!");
                            isValidOperation = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Błąd: Nieznana operacja!");
                        isValidOperation = false;
                        break;
                }

                // Wyświetlenie wyniku
                if (isValidOperation)
                {
                    // Używamy culture do formatowania wyniku (kropka jako separator)
                    Console.WriteLine($"Wynik: {result.ToString(culture)}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Nie można przekonwertować podanych wartości na liczby. Upewnij się, że format jest poprawny.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");

            }
        }

        static void TemperatureConverter()
        {
            Console.WriteLine("Podaj kierunek konwersji (C lub F) i temperaturę, oddzielone ', ' (np. C, 0):");
            string input = Console.ReadLine();

            // Ustawienie kultury na niezmienną dla parsowania i formatowania
            CultureInfo culture = CultureInfo.InvariantCulture;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Błąd: Nie podano danych wejściowych.");
                return;
            }

            // Podział wejścia
            string[] parts = input.Split(new[] { ", " }, StringSplitOptions.None);

            // Sprawdzenie, czy mamy dokładnie 2 części
            if (parts.Length != 2)
            {
                Console.WriteLine("Błąd: Niepoprawny format wejścia. Oczekiwano formatu: Kierunek, Wartość (np. C, 0)");
                return;
            }

            try
            {
                // Pobranie kierunku i konwersja na wielkie litery
                string kierunek = parts[0].Trim().ToUpper();

                // Parsowanie temperatury
                double temperatura = double.Parse(parts[1].Trim(), culture);

                // Wykonanie konwersji
                if (kierunek == "C")
                {
                    double tempFahrenheit = temperatura * 1.8 + 32;
                    Console.WriteLine($"{temperatura.ToString("F0", culture)}°C = {tempFahrenheit.ToString("F0", culture)}°F");
                }
                else if (kierunek == "F")
                {
                    double tempCelsjusz = (temperatura - 32) / 1.8;
                    Console.WriteLine($"{temperatura.ToString("F0", culture)}°F = {tempCelsjusz.ToString("F0", culture)}°C");
                }
                else
                {
                    Console.WriteLine("Błąd: Niepoprawny kierunek konwersji. Oczekiwano 'C' lub 'F'.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Nie można przekonwertować podanej wartości temperatury na liczbę.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }

        static void StudentGrades()
        {
            Console.WriteLine("Podaj oceny (1-6), oddzielone ', ' (np. 4, 5, 3, 4, 2):");
            string input = Console.ReadLine();

            CultureInfo culture = CultureInfo.InvariantCulture; // Dla spójnego formatowania wyniku

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Błąd: Nie podano danych wejściowych.");
                return;
            }

            // Podział wejścia
            string[] parts = input.Split(new[] { ", " }, StringSplitOptions.None);

            if (parts.Length == 0)
            {
                Console.WriteLine("Błąd: Nie podano żadnych ocen.");
                return;
            }

            List<int> grades = new List<int>();
            try
            {
                foreach (string part in parts)
                {
                    if (int.TryParse(part.Trim(), out int grade) && grade >= 1 && grade <= 6)
                    {
                        grades.Add(grade);
                    }
                    else
                    {
                        Console.WriteLine($"Błąd: Niepoprawna wartość oceny '{part.Trim()}'. Oceny muszą być liczbami całkowitymi z zakresu 1-6.");
                        return;
                    }
                }

                if (grades.Count > 0)
                {
                    // Obliczanie średniej
                    double avg = grades.Average();

                    // Wyświetlenie wyniku
                    Console.WriteLine($"Średnia: {avg.ToString("F2", culture)}");

                    // Sprawdzenie warunku zaliczenia
                    if (avg >= 3.0)
                    {
                        Console.WriteLine("Uczeń zdał.");
                    }
                    else
                    {
                        Console.WriteLine("Uczeń nie zdał.");
                    }
                }
                else
                {
                    Console.WriteLine("Błąd: Nie podano poprawnych ocen.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd formatowania danych wejściowych.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
