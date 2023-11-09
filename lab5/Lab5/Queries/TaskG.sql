/*Вивести всі прийоми в порядку зростання часу їх початку */

SELECT  clinic_employee.FullName, appointment.Room, appointment.Start
FROM clinic_employee 
INNER JOIN appointment ON clinic_employee.Id = appointment.ClinicEmployeeId
ORDER BY appointment.Start;