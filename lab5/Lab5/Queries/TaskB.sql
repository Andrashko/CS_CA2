/* Знайдемо лікарів, прізвище яких починається із Var..*/
SELECT *
FROM clinic_employee
WHERE FullName LIKE 'Var%';