# Password Generator 🔒

A lightweight and secure tool for generating random passwords, built with Windows Forms to provide a user-friendly graphical interface. The **Password Generator** ensures strong, unique passwords, helping enhance your security against threats.

## Features 🌟

- **Customizable Password Length:** Generate passwords of any length to suit your needs.
- **Character Set Options:** Include or exclude:
  - 🔠 Uppercase letters
  - 🔡 Lowercase letters
  - 🔢 Numbers
  - 🛠 Special characters
- **Secure Randomness:** Cryptographically secure random generation.
- **Intuitive Windows Forms Interface:** Easy-to-use graphical interface for everyone.
- **Copy to Clipboard:** Quickly copy generated passwords for seamless use.

## Table of Contents 📋

1. [Getting Started](#getting-started)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Configuration](#configuration)
5. [Contributing](#contributing)
6. [License](#license)

## Getting Started 🚀

This project helps users create secure passwords with a clean, responsive Windows Forms interface. Ideal for personal and professional use.

## Installation 🛠

### Clone the Repository
```bash
$ git clone https://github.com/your-username/password-generator.git
$ cd password-generator
```

### Build the Project
This project requires Visual Studio with .NET Framework support. Open the `.sln` file and build the solution.

### Run the Application
Run the application directly from Visual Studio or build it into an executable file.

## Usage ⚙️

Launch the application, and the Windows Forms interface will guide you through password generation. Customize settings such as length, character sets, and more.

### Features in the Interface:
- **Length Selector:** Adjust the slider or input a value for the password length.
- **Checkboxes for Character Types:** Toggle uppercase, lowercase, numbers, and special characters.
- **Generate Button:** Click to create a password.
- **Copy Button:** Instantly copy the password to your clipboard.

### Example Workflow:
1. Set the desired password length (e.g., 16 characters).
2. Select the types of characters to include.
3. Click **Generate** to create a password.
4. Use the **Copy** button to save it to your clipboard.

## Configuration ⚙️

Default settings can be adjusted in the source code for tailored behavior:
```csharp
public static class Config {
    public const int DefaultLength = 12;
    public const bool IncludeSpecial = true;
    public const bool IncludeNumbers = true;
    public const bool IncludeUppercase = true;
    public const bool IncludeLowercase = true;
}
```

## Contributing 🤝

We welcome contributions! Follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -m "Add new feature"`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a Pull Request.

Please ensure any new features or bug fixes are tested before submitting.

## License 📄

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

### Screenshot 📸



### Example Output 🧪

Generated Password Example: `A$9v!F2k^GzP&x1W`

