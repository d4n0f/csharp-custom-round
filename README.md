# Custom Round Function in C#

This is a custom implementation of the round() function in C#, designed to handle rounding floating-point numbers.

## Features

- **Dynamic Decimal Handling:**  
  The program adjusts dynamically to the number of decimal places in the input value and rounds the number accordingly.
  
- **Default Decimal Handling:**  
  If no decimal places are provided, the function rounds based on the input number's inherent decimal places.
  
- **Rounding to More Decimal Places:**  
  The function can round the number to more decimal places than the original value, allowing for precise control over the result.
  
- **Rounding to Fewer Decimal Places (Positive Numbers):**  
  If you specify fewer decimal places, the program rounds the value to a positive number with the requested precision.

- **Rounding to Zero Decimal Places:**  
  The function rounds the number to the nearest whole number (integer) when 0 decimal places are requested.

- **Handling Negative Numbers:**  
  The program correctly handles negative numbers and rounds them as required by the rounding rules.

- **Error Handling:**  
  The program checks for invalid input and ensures proper rounding behavior, preventing errors like division by zero or invalid values. It also examines the user's input and automatically corrects minor mistakes.

## Usage

```csharp
// General case
float floatNumber = 2,172;
int decimalPlaces = 1;
kerekites(floatNumber, decimalPlaces); // Output: 2,2

// Rounding to a higher decimal place
float floatNumber = 3,5;
int decimalPlaces = 3;
kerekites(floatNumber, decimalPlaces); // Output: 3,500

// Negative decimal places handling
float floatNumber = 12,562;
int decimalPlaces = -1;
kerekites(floatNumber, decimalPlaces); // Output: 10
```

## Limitations

- For most cases it works accurately.
- In some cases it might exhibit issues due to floating-point representation limitations. For example: instead of rounding to 2 the result is 1.9999.

## License

This project is licensed under the GPL License - see the [LICENSE](LICENSE) file for details.
