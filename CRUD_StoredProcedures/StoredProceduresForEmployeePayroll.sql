USE EMPLOYEE_PAY
SELECT * FROM EmployeePay

--Add New Employee to Database
CREATE PROCEDURE SPAddNewEmployee(
@EmployeeId INT,
@EmployeeName VARCHAR(40),
@Gender CHAR(1),
@PhoneNo BIGINT,
@EmployeeAddress VARCHAR(100),
@CompanyName VARCHAR(30),
@StartDate DATE 
)
AS BEGIN
INSERT INTO EmployeePay VALUES(@EmployeeName,@Gender,@PhoneNo,@EmployeeAddress,@CompanyName,@StartDate)
END

--Retrieving All Details From EmployeePay
CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM EmployeePay
END

--Update Data in EmployeePay Database
CREATE PROCEDURE SPUpdateDataInDB(
@EmployeeName VARCHAR(30),
@CompanyName VARCHAR(20),
@PhoneNo VARCHAR(20)
)
AS BEGIN
UPDATE EmployeePay SET CompanyName=@CompanyName,PhoneNo=@PhoneNo WHERE EmployeeName=@EmployeeName
END

--Deleting data from EmployeePay Database
CREATE PROCEDURE SPDeleteDataFromDB(
@EmployeeName VARCHAR(30)
)
AS BEGIN
DELETE FROM EmployeePay WHERE EmployeeName=@EmployeeName
END