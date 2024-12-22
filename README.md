# 🕸️ WebScraping4devs

## 🌟 Project Overview

**WebScraping4devs** is a web scraping application designed to extract:

- 🆔 **CPF numbers**
- 💳 **Credit card details**

The project leverages **Selenium** for web automation and **CsvHelper** for CSV file manipulation. Extracted data is saved into CSV files for further use.

---

## ✨ Features

### 🆔 CPF Extraction
- Navigates to a specified URL.
- Generates a specified number of CPF numbers.
- Saves the data into a CSV file.

### 💳 Credit Card Number Extraction
- Navigates to a specified URL.
- Generates credit card numbers for a given card type (e.g., MasterCard, Visa).
- Saves the data into a CSV file.

### 📂 CSV File Saving
- Utilizes the CsvHelper library for structured CSV file manipulation.

---

## 📦 Libraries Used

- **Selenium.WebDriver** 🕵️‍♂️: Automates web browser interaction to navigate web pages and extract data.
- **CsvHelper** 🗂️: Reads and writes CSV files to save the extracted data.

---

## 🏗️ Project Structure

The project is organized as follows:

- **📂 Driver**: Contains the main web scraping logic.
  - `WebScraping.cs`: Implements web scraping functionality and CSV file saving.
- **📂 Enum**: Contains enumerations used in the project.
  - `Flag.cs`: Defines the `Flag` enumeration for different credit card types.
- **📂 Model**: Contains data models.
  - `Cpf.cs`: Defines the `Cpf` class for CPF data.
  - `CreditCard.cs`: Defines the `CreditCard` class for credit card data.
- **🚀 Program.cs**: The entry point of the application.
- **📄 WebScraping4devs.csproj**: Project configuration and dependencies.
- **📂 WebScraping4devs.sln**: Solution file for Visual Studio.

---

## 🚀 Usage

To run the project, follow these steps:

1. **Execute the Main method** in `Program.cs`.
2. The application will:
   - Instantiate the `WebScraping` class.
   - Call `GetCPF` to extract CPF numbers and save them to a CSV file.
   - Call `GetCardNumber` to extract credit card numbers and save them to a CSV file.
   - Close the web driver.

---

## 💡 Summary

This project demonstrates:

- 🕵️‍♀️ The use of Selenium for web scraping.
- 📂 The use of CsvHelper for CSV file manipulation.

It's a practical example of leveraging powerful libraries for data extraction in a .NET application. 🚀
