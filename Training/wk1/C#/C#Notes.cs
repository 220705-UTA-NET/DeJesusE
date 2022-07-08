
Console.WriteLine("Hello, World!"); // Writes to the console
Console.Write("Text"); // Same as Console.WriteLine but doesn't automatically end the line.

Console.ReadLine(); // Reads from the console

//EVERYTHING IS AN OBJECT
// A object is a real world entity with state and behaviour

// Statically type - declare the type before compiling
// Dynamically type - declare the type during compiling

// Primitive Data Types
bool b = true; // Boolean - true or false

sbyte level = 23; // Signed Integral - (+/-) integer, size: 1 byte
byte bite = 62; // Unsigned Integral - (+) integer, size: 1 byte

short b = 5; //short - a small integer, size: 2 bytes
ushort value = 12312; // Unsigned short - (+) small integer, size: 2 bytes

int x = 5; // integer - (whole number), size: 4 bytes
uint y = 65535; // Unsigned integer - a (+) whole number, size: 4 bytes

long l = 5; // long - a large integer, size: 8 bytes
ulong ul = 1151092; // Unsigned long -  a (+) large integer, size: 8 bytes

float f = 5.5f; // float - a single-precision floating-point decimal, size: 4 bytes
double z = 5.5; // double - a double-precision floating-point decimal, size 8 bytes

// char - a single (unicode) character, size: 2 bytes 
char c1 = 'x';
char c2 = '\u0042';

decimal gpa = 3.5m; // decimal - a decimal; has more precision and smaller range than float; suitable for monetary calculations; size: 16 bytes
