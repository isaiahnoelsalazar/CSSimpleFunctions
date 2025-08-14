# How to install?
### In Visual Studio
#### Step 1
- Go to "Tools > NuGet Package Manager > Manage NuGet Packages for Solution"
#### Step 2
- Go to "Browse" tab and search for "CSSimpleFunctions" and simply install the latest version

### In Visual Studio Package Manager Console
```
dotnet add package CSSimpleFunctions --version [latest release version]
```
> Note: Remove the brackets for version

# Available methods
- [Check](#check)
- [Convert](#convert)
- [PyCS](#pycs)

## Check
### HasNumbers
- will check a String for a number
- returns a boolean value
```csharp
Check.HasNumbers("Sample text"); // returns false
Check.HasNumbers("Sample text 1"); // returns true
```
### HasSymbols
- will check a String for a symbol
- returns a boolean value
```csharp
Check.HasSymbols("Sample text"); // returns false
Check.HasSymbols("Sample text!"); // returns true
```
### HasSpaces
- will check a String for a space
- returns a boolean value
```csharp
Check.HasSpaces("Sample_text"); // returns false
Check.HasSpaces("Sample text"); // returns true
```
## Convert
### ToBase64
- will convert a String to its Base64 version
- returns a String
```csharp
Convert.ToBase64("Sample text"); // returns "U2FtcGxlIHRleHQ="
```
### FromBase64
- will convert a Base64 String to its normal version
- returns a String
```csharp
Convert.FromBase64("U2FtcGxlIHRleHQ="); // returns "Sample text"
```
## PyCS
### Initialization
```csharp
PyCS pycs = new PyCS();

// Or

PyCS pycs = new PyCS(true); // default value
PyCS pycs = new PyCS(false); // no console messages
```
### pip
- starts a pip install command
```csharp
pycs.pip(new string[]{"opencv-python"});
```
### run
- runs a given Python script in a string value
```csharp
pycs.run("print('Hello')"); // prints "Hello" in the console
```
### runFile
- runs a given Python script in a given file path
```csharp
pycs.run("scripts/hello.py"); // prints "Hello" in the console
```
### backRun
- runs a given Python script in a string value and returns the console message in a string value
```csharp
string text = pycs.backRun("print('Hello')"); // returns "Hello"
```
### backRunFile
- runs a given Python script in a given file path and returns the console message in a string value
```csharp
string text = pycs.backRunFile("scripts/hello.py"); // returns "Hello"
```