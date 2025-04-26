def main() -> None:
    print("Wybierz zadanie")

    print("Zadanie 1: Prosty kalkulator dwóch liczb")
    print("Zadanie 2: Konwerter temperatur (Celsjusz <-> Fahrenheit)")
    print("Zadanie 3: Średnia ocen ucznia")

    choice = int(input())

    if choice == 1:
        calculator()
    elif choice == 2:
        temperature_converter()
    elif choice == 3:
        student_grades()
    else:
        print("Nieprawidłowy wybór")
        return


def calculator() -> None:
    userInput = input("Podaj dwie liczby i operację, oddzielone ', ' (np. 10, 20, +): ")

    if not userInput:
        print("Błąd: Nie podano danych wejściowych.")
        return

    # Podział wejścia na części
    parts = userInput.split(', ')

    # Sprawdzenie, czy mamy dokładnie 3 części
    if len(parts) != 3:
        print("Błąd: Niepoprawny format wejścia. Oczekiwano formatu: liczba1, liczba2, operacja")
        return

    try:
        # Parsowanie liczb (używamy strip() do usunięcia białych znaków)
        # Zamieniamy przecinki na kropki dla pewności przed konwersją na float
        num1 = float(parts[0].strip().replace(',', '.'))
        num2 = float(parts[1].strip().replace(',', '.'))

        # Pobranie operacji
        op = parts[2].strip()

        if len(op) != 1:
            print("Błąd: Niepoprawny operator. Oczekiwano pojedynczego znaku (+, -, *, /).")
            return

        result = None

        # Wykonanie obliczeń
        if op == '+':
            result = num1 + num2
        elif op == '-':
            result = num1 - num2
        elif op == '*':
            result = num1 * num2
        elif op == '/':
            if num2 != 0:
                result = num1 / num2
            else:
                print("Błąd: Nie można dzielić przez zero!")
        else:
            print("Błąd: Nieznana operacja!")

        # Wyświetlenie wyniku
        if result is not None:
            # Formatowanie, aby uniknąć .0 dla liczb całkowitych
            if result == int(result):
                print(f"Wynik: {int(result)}")
            else:
                print(f"Wynik: {result}")

    except ValueError:
        print("Błąd: Nie można przekonwertować podanych wartości na liczby. Upewnij się, że format jest poprawny.")
    except Exception as e:
        print(f"Wystąpił nieoczekiwany błąd: {e}")


def temperature_converter() -> None:
    userInput = input("Podaj kierunek (C lub F) i temperaturę, oddzielone ', ' (np. C, 0): ")

    if not userInput:
        print("Błąd: Nie podano danych wejściowych.")
        return

    # Podział wejścia
    parts = userInput.split(', ')

    # Sprawdzenie, czy mamy dokładnie 2 części
    if len(parts) != 2:
        print("Błąd: Niepoprawny format wejścia. Oczekiwano formatu: Kierunek, Wartość (np. C, 0)")
        return

    try:
        # Pobranie kierunku
        conversionTo = parts[0].strip().upper()

        # Parsowanie temperatury (z zamianą przecinka na kropkę)
        temperature_str = parts[1].strip()
        temperature = float(temperature_str.replace(',', '.'))

        # Wykonanie konwersji
        if conversionTo == 'C':
            temperature_fahrenheit = temperature * 1.8 + 32
            print(f"{temperature:.0f}°C = {temperature_fahrenheit:.0f}°F")
        elif conversionTo == 'F':
            temperature_celsjusz = (temperature - 32) / 1.8
            print(f"{temperature:.0f}°F = {temperature_celsjusz:.0f}°C")
        else:
            print("Błąd: Niepoprawny kierunek konwersji. Oczekiwano 'C' lub 'F'.")

    except ValueError:
        print("Błąd: Nie można przekonwertować podanej wartości temperatury na liczbę.")
    except Exception as e:
        print(f"Wystąpił nieoczekiwany błąd: {e}")


def student_grades() -> None:
    userInput = input("Podaj oceny (1-6), oddzielone ', ' (np. 4, 5, 3, 4, 2): ")

    if not userInput:
        print("Błąd: Nie podano danych wejściowych.")
        return

    # Podział wejścia
    parts = userInput.split(', ')

    oceny = []
    suma_ocen = 0
    poprawne_oceny = True

    if not parts or all(not part.strip() for part in parts):
        print("Błąd: Nie podano żadnych ocen.")
        return

    # Przetwarzanie ocen
    for ocena_str in parts:
        try:
            ocena = int(ocena_str.strip())
            if 1 <= ocena <= 6:
                oceny.append(ocena)
                suma_ocen += ocena
            else:
                print(f"Błąd: Ocena '{ocena_str.strip()}' jest poza zakresem 1-6.")
                poprawne_oceny = False
                break # Przerywamy pętlę przy pierwszym błędzie
        except ValueError:
            print(f"Błąd: Nie można przekonwertować '{ocena_str.strip()}' na ocenę (liczbę całkowitą).")
            poprawne_oceny = False
            break # Przerywamy pętlę przy pierwszym błędzie

    # Jeśli wszystkie oceny były poprawne, obliczamy średnią
    if poprawne_oceny and oceny:
        srednia = suma_ocen / len(oceny)
        print(f"Średnia: {srednia:.2f}")

        # Sprawdzenie warunku zaliczenia
        if srednia >= 3.0:
            print("Uczeń zdał.")
        else:
            print("Uczeń nie zdał.")
    elif poprawne_oceny and not oceny:
        print("Błąd: Nie podano poprawnych ocen.")


if __name__ == "__main__":
    main()
