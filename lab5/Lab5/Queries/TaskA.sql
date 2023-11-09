/* Вибрати всіх лікарів  які приймають в понеділок */
SELECT  clinic_employee.FullName, appointment.Room, appointment.Day
FROM clinic_employee 
INNER JOIN appointment ON clinic_employee.Id = appointment.ClinicEmployeeId
WHERE appointment.Day = 1;