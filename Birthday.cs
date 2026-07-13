using System.Globalization;

Console.Write("Enter your birthdate (MM/dd/yyyy): ");
bool isValid = DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture,
    DateTimeStyles.None, out DateTime birthdate);

while (isValid == false)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.Write("INVALID!!! Enter your birthdate (MM/dd/yyyy): ");
    Console.ResetColor();
    isValid = DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture,
        DateTimeStyles.None, out birthdate);
}

DateTime today = DateTime.Today;
int age = today.Year - birthdate.Year;
if (birthdate.DayOfYear < today.DayOfYear) age--;
Console.WriteLine($"You are {age} years old.");

if (today.Day == birthdate.Day && today.Month == birthdate.Month)
{
    Console.WriteLine("Happy Birthday");
}
else
{
    DateTime nextBD = new DateTime(today.Year, birthdate.Month, birthdate.Day);
    if (nextBD < today)
    {
        nextBD = nextBD.AddYears(1);
    }
    int days = (nextBD - today).Days;
    Console.WriteLine($"Your next birthday is in {days} day(s).");
}
