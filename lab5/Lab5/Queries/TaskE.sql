/* порахувати тривалість кожного прийому*/

SELECT DATEDIFF(MINUTE, StartTime , EndTime) AS AppointmentTime
FROM appointment;
