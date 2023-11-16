/* порахувати тривалість кожного прийому*/

SELECT DATEDIFF(MINUTE, StartTime , EndTime) AS ApointmanetTime
FROM appointment;