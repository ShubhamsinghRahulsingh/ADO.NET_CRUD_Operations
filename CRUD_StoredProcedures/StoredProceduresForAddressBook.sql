--Adding new AddressBook
CREATE PROCEDURE SPAddingNewData(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Address VARCHAR(100),
@City VARCHAR(20),
@State VARCHAR(20),
@ZIP INT,
@PhoneNumber BIGINT,
@Email VARCHAR(50)
)
AS BEGIN
INSERT INTO AddressBookADO(FirstName,LastName,Address,City,State,ZIP,PhoneNumber,Email)
VALUES(@FirstName,@LastName,@Address,@City,@State,@ZIP,@PhoneNumber,@Email)
END

--Retrieving All Details From AddressBook
CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM AddressBookADO
END

--Update Data in AddressBook Database
CREATE PROCEDURE SPUpdateDataInDB(
@FirstName VARCHAR(30),
@City VARCHAR(20),
@State VARCHAR(20)
)
AS BEGIN
UPDATE AddressBookADO SET City=@City,State=@State WHERE FirstName=@FirstName
END

