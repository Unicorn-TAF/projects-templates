![Nuget](https://img.shields.io/nuget/v/Unicorn.Taf.Templates?style=plastic) ![Nuget](https://img.shields.io/nuget/dt/Unicorn.Taf.Templates?style=plastic)

# Unicorn.Taf.Templates

Templates for Unicorn test automation framework based projects.

Firstly install the package using `dotnet new install Unicorn.Taf.Templates`

Available templates are:
```
Template Name                         Short Name           Language  Tags
------------------------------------  -------------------  --------  -------------------
Unicorn Tests project                 unicorn              [C#]      Testing/Unicorn.TAF
Unicorn Test suite                    unicorn-suite        [C#]      Testing/Unicorn.TAF
Unicorn Test steps injection project  unicorn-steps        [C#]      Testing/Unicorn.TAF
Unicorn Test steps class              unicorn-steps-class  [C#]      Testing/Unicorn.TAF
Unicorn Web module project            unicorn-web          [C#]      Testing/Unicorn.TAF
Unicorn Web page                      unicorn-web-page     [C#]      Testing/Unicorn.TAF
Unicorn Win module project            unicorn-win          [C#]      Testing/Unicorn.TAF
Unicorn Win (desktop) window          unicorn-win-window   [C#]      Testing/Unicorn.TAF
```

# Tests

## Project
To create new tests project use `unicorn` template. The template provides with ability to initialize the project with build-in integration with reporting tools: Allure, ReportPortal or TestIT. Corresponding reporter initialization config template is also added if reporting integration is specified. The template creates a project with predefined `[TestsAssembly]` class, empty suite class and test suite showcase example.

Available template options:
```
-f, --framework       Target framework
                      Default: net8.0
-r, --reporting       External reporting system to use
                      Available values:
                        - none          No reporting
                        - reportportal  Use Report Portal as external reporting system
                        - allure        Use Allure reports as external reporting system
                        - testit        use TestIT as external reporting system
```

Examples:
```bash
# initialize new project with default name `Company.Tests` in current directory
dotnet new unicorn

# initialize new project with name `TestsProject` in TestsProject directory
dotnet new unicorn -o TestsProject

# initialize new project with name `TestsProject` in TestsProject directory with pre-initialized reporting to ReporPortal and targeting net9.0
dotnet new unicorn -o TestsProject --reporting reportportal --framework net9.0
```

## Test Suite

To create new test suite class use `unicorn-suite` template.

Available template options:
```
-p:n, --namespace     The namespace to place class in.
                      Default: Company.Tests
```

# Steps

## Steps injection project

`unicorn-steps` template allows one to create ready for use implementation of test steps injection which could be referenced by other projects.

Available template options:
```
-f, --framework       Target framework
                      Default: net8.0
```

Examples:
```bash
# initialize new steps injection project with name `StepsInjection` in directory StepsInjection
dotnet new unicorn-steps -o StepsInjection
```

## Steps class

To create new steps class use `unicorn-steps-class` template.

Available template options:
```
Required
-in, --injection-namespace      The namespace of Steps injection attribute (StepsClassAttribute)
                                Default: Company.StepsInjection

Optional
-p:n, --namespace               The namespace to place class in.
                                Default: Company.Steps
```

# Web UI module project

## Project

`unicorn-web` template is used to create a project for some Web component. The template creates a project with predefined Website and empty Web Page classes.

Available template options:
```
-f, --framework       Target framework
                      Default: net8.0
```

Examples:
```bash
# initialize new web automation project with name `WebModule` in directory WebModule
dotnet new unicorn-web -o WebModule
```

## Web Page
`unicorn-web-page` template is used to create a new Web Page class with a predefined control initialization example.

Available template options:
```
-p:n, --namespace     The namespace to place class in.
                      Default: Company.WebModule
```

# Windows UI module

## Project

`unicorn-win` template is used to create a project for some Windows application. The template creates a project with predefined Application and empty Window classes.

Available template options:
```
-f, --framework       Target framework
                      Default: net8.0-windows
```

Examples:
```bash
# initialize new windows application automation project with name `WinModule` in directory WinModule
dotnet new unicorn-win -o WinModule
```

## Window class

`unicorn-win-window` template is used to create a new Window control class with a predefined control initialization example.

Available template options:
```
-p:n, --namespace     The namespace to place class in.
                      Default: Company.WinModule
```