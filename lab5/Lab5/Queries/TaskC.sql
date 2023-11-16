/* Знайдемо всіх дерматологів, які приймають після 10:00 */
SELECT  clinic_employee.FullName, clinic_employee.Speciality, appointment.Room, appointment.Day, appointment.StartTime
FROM clinic_employee 
INNER JOIN appointment ON clinic_employee.Id = appointment.ClinicEmployeeId
WHERE appointment.StartTime > '10:00:00' 
AND clinic_employee.Speciality='Dermatolog';