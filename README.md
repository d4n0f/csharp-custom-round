# Custom Round Function (C#)

This is a custom implementation of the round() function in C#, designed to handle rounding floating-point numbers.

## Features

- **Dynamic Decimal Handling:**  
  The program adjusts dynamically to the number of decimal places in the input value and rounds the number accordingly.
  
- **Default Decimal Handling:**  
  If the given float value and the decimal place match, the result remains the same as the input number.
  
- **Rounding to More Decimal Places:**  
  The function can round the number to more decimal places than the original value, allowing for precise control over the result.
  
- **Rounding to Fewer but Positive Decimal Places:**  
  If you specify fewer but positive decimal places, the program rounds the value to a number with the requested precision.

- **Rounding to Zero Decimal Places:**  
  The function rounds the number to the nearest whole number (integer) when 0 decimal places are requested.

- **Handling Negative Numbers:**  
  The program correctly handles negative numbers and rounds them as required by the rounding rules.

- **Error Handling:**  
  The program checks for invalid input and ensures proper rounding behavior, preventing errors like division by zero or invalid values. It also examines the user's input and automatically corrects minor mistakes.

## Usage

```csharp
// General case
double floatingNumber = 2,172;
int decimalPlaces = 1;
Kerekites(floatingNumber, decimalPlaces); // Output: 2,2

// Rounding to a higher decimal place
double floatingNumber = 3,5;
int decimalPlaces = 3;
Kerekites(floatingNumber, decimalPlaces); // Output: 3,500

// Negative decimal places handling
double floatingNumber = 12,562;
int decimalPlaces = -1;
Kerekites(floatingNumber, decimalPlaces); // Output: 10
```

## Limitations

- For most cases it works accurately.
- In some cases it might exhibit issues due to floating-point representation limitations. For example: instead of rounding to 2 the result is 1.9999.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for more details.
