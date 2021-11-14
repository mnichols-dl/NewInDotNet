// ========================================== DateOnly ============================================= //

// DateTime has typically been used in .NET to represent specific points in time

using NIDN.DateOnlyTimeOnly.Helpers;

var newYearsEve = new DateTime(2021, 12, 31, 19, 0, 0, DateTimeKind.Local);
Console.WriteLine($"New Year's Eve as DateTime (local): {newYearsEve} (or formatted as date only: {newYearsEve:D})");

// In many cases only the Date portion is needed. Because DateTime always factors in
// a time component (even if it is not specified in the constructor), there is a risk of
// unexpected results, particularly with time zones.

// As universal time, what was expected to be 12/31/2021 may now be 1/1/2022
Console.WriteLine($"New Year's Eve as DateTime (universal): {newYearsEve.ToUniversalTime()} (or formatted as date only: {newYearsEve.ToUniversalTime():D})");

// A new type DateOnly was introduced to model only the date
var newYearsDay = new DateOnly(2022, 1, 1);

// Similar formatting options are available, like `D` which is a "long date"
Console.WriteLine($"New Year's Day as DateOnly: {newYearsDay} (or formatted as: {newYearsDay:D})");

// ========================================== TimeOnly ============================================= //

// Similarly, DateTime or TimeSpan were used (or abused) to meet the needs of
// representing only time
var sixAm = new TimeSpan(6, 0, 0);

// TimeSpan is not a true representation of time of day though. For instance, adding and subtracting
// often required custom "wrap-around" handling.
Console.WriteLine($"{sixAm} minus 7 hours equals {sixAm.Subtract(new TimeSpan(7,0,0))}");

// Even using DateTime (which has some of this wrap-around ready to go),
// there is still a question of what the date component should be.
var yearOne = new DateTime(1, 1, 1, 3, 15, 0);

// A new type TimeOnly was introduced to model only the time
var midnight = new TimeOnly(0, 0, 0);

// Subtraction is handled better
Console.WriteLine($"{midnight} minus 3 hours equals {midnight.AddHours(-3)} (or formatted as {midnight.AddHours(-3):h:mm:ss tt})");

// =================================== DateTime Compatibility ====================================== //

// Both DateOnly and TimeOnly have methods for cleanly getting only one part of a DateTime
var newYearsEveAsDate = DateOnly.FromDateTime(newYearsEve);
Console.WriteLine($"New Year's Eve DateTime ({newYearsEve}) converted to DateOnly is {newYearsEveAsDate}");

var sixAmAsTime = TimeOnly.FromTimeSpan(sixAm);
Console.WriteLine($"Six AM TimeSpan ({sixAm}) converted to TimeOnly is {sixAmAsTime}");

// DateOnly and TimeOnly can both be converted to DateTime as well, but the missing component must be supplied
var backToDateTime = newYearsEveAsDate.ToDateTime(midnight);
Console.WriteLine($"Combining New Year's Eve DateOnly and midnight TimeOnly produces the DateTime {backToDateTime}");

// ========================== Operators available (and not available) ============================== //

var timeDiff = sixAmAsTime - midnight;
var timeIncremented = midnight.Add(timeDiff); // No + operand for TimeOnly + TimeSpan

// Some operators are not overloaded on these new times, like subtracting. The `DayNumber` property
// is the total number of days since the start of the calendar (1/1/0001), and is useful for subtraction.
var dateDiff = newYearsDay.DayNumber - newYearsEveAsDate.DayNumber;

// An extension method is included in this project to make this less painful
var dateDiff2 = newYearsDay.Subtract(newYearsEveAsDate).Days;

// ========================================= Other helpers ========================================= //
var currentTime = TimeOnlyExtensions.CurrentTimeLocal();
var currentTimeUtc = TimeOnlyExtensions.CurrentTimeUtc();
var currentDate = DateOnlyExtensions.CurrentDateLocal();
var currentDateUtc = DateOnlyExtensions.CurrentDateUtc();