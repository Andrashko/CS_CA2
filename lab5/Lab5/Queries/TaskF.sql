/* кількість прийомів в кожному з кабінетів Де кількість прийомів більша за 1*/
SELECT COUNT(*) AS AppointmentCount, Room
FROM appointment
GROUP BY Room
HAVING COUNT(*)>1;
