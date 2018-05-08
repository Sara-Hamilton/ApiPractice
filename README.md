# API Practice

##### An app that retirieves and displays GitHub repo info using the GitHub API, Visual Studio MVC, C#, and .NET.  05/7/18

## By Sara Hamilton and Johnny Mayer

# Description
This is an Epicodus practice project for week 4 of the .NET course.  Its purpose is to display understanding of using API requests to retrieve data using Visual Studio and MVC.  


## Technologies Used
* HTML
* CSS
* Bootstrap
* Visual Studio
* C#
* .NET
* GitHub API

## Set up a GitHub account
Make a free GitHub account. 

## Configure EnvironmentVariables

Open the app solution in Visual Studio.  In the Models folder, create a class named EnvironmentVariables.cs  Add the following code to EnvironmentVariables.cs  Replace the text that is in all caps with your GitHub username or email.  

```
namespace ApiPractice.Models
{
    public static class EnvironmentVariables
    {
        public static string AccountUserAgent = "YOUR ACCOUNT CREDENTIALS HERE";
    }
}
```

## Run the Application  

  * _Clone the github respository_
  ```
  $ git clone https://github.com/Sara-Hamilton/ApiPractice
  ```
* _Move into the directory_
```
$ cd ApiPractice
```
*  _Restore the program_

 ```
 $ dotnet restore
 ```
Open the program in Visual Studio and run the program.

### License

*MIT License*

Copyright (c) 2018 **_Sara Hamilton and Johnny Mayer_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.