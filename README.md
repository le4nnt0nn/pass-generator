# Password Generator 🔒

A lightweight and secure tool for generating random passwords to enhance your online security. The **Password Generator** ensures that your passwords are strong, unique, and resistant to brute-force attacks.

## Features 🌟

- **Customizable Password Length:** Generate passwords of any length to suit your needs.
- **Character Set Options:** Include or exclude:
  - 🔠 Uppercase letters
  - 🔡 Lowercase letters
  - 🔢 Numbers
  - 🛠 Special characters
- **Secure Randomness:** Uses cryptographically secure random number generation for added security.
- **User-Friendly Interface:** Simple and intuitive design for both technical and non-technical users.
- **Open Source:** Fully transparent codebase.

## Table of Contents 📋

1. [Getting Started](#getting-started)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Configuration](#configuration)
5. [Contributing](#contributing)
6. [License](#license)

## Getting Started 🚀

This project is designed to help users create secure passwords quickly. Whether you're securing personal accounts or enterprise systems, the Password Generator provides a reliable solution.

## Installation 🛠

### Clone the Repository
```bash
$ git clone https://github.com/your-username/password-generator.git
$ cd password-generator
```

### Build the Project
This project requires .NET 6 or higher. Build the project using the .NET CLI:
```bash
$ dotnet build
```

## Usage ⚙️

Run the tool directly from the command line or integrate it into your own projects. (C# example)

### Command Line Usage
```bash
$ dotnet run --length 16 --include-special --exclude-numbers
```

#### Options:
- `--length` : Specify the length of the password (default: 12).
- `--include-special` : Include special characters in the password.
- `--exclude-numbers` : Exclude numbers from the password.
- `--help` : View all options.

### Integration in C# Code
You can also use the Password Generator as a library in your C# projects:

```csharp
using PasswordGenerator;

// Generate a password with custom settings
var password = PasswordGenerator.GeneratePassword(length: 16, includeSpecial: true, excludeNumbers: true);
Console.WriteLine($"Generated password: {password}");
```

## Configuration ⚙️

Edit the default settings in `appsettings.json` to customize the behavior of the password generator:
```json
{
  "DefaultLength": 12,
  "IncludeSpecial": true,
  "ExcludeNumbers": false
}
```

## Contributing 🤝

We welcome contributions! Follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -m "Add new feature"`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a Pull Request.

Please make sure to include tests for your new features or bug fixes :).

## License 📄

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

### Example Output 🧪

```bash
$ dotnet run --length 16 --include-special
Generated password: A$9v!F2k^GzP&x1W
```

