// Using statements must come first in the file.

using System;
using System.IO;

Console.WriteLine("Hello, World!");

// Behind the scenes, the compiler is placing this in the usual `public static void Main(string[] args)` method body.
// It will also recognize when the method should be made async automatically. Uncomment the following async
// method, rebuild, and decompile with ILSpy to verify.

var readme = await File.ReadAllTextAsync("README.md");

// Visual Studio and the compiler both will understand that the `string[] args` parameter is still available.
Console.WriteLine(args);
