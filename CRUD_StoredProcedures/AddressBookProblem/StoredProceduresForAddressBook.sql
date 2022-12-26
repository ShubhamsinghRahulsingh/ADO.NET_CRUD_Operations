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

