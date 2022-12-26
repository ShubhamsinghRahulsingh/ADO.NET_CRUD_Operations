CREATE Database AddressBook
USE AddressBook;

CREATE TABLE AddressBookADO(
FirstName VARCHAR(30) PRIMARY KEY NOT NULL,
LastName VARCHAR(30),
Address VARCHAR(100) NOT NULL,
City VARCHAR(20) NOT NULL,
State VARCHAR(20) NOT NULL,
ZIP INT NOT NULL,
PhoneNumber BIGINT NOT NULL,
Email VARCHAR(50) NOT NULL
);
SELECT * FROM AddressBookADO

INSERT INTO AddressBookADO(FirstName,LastName,Address,City,State,ZIP,PhoneNumber,Email)VALUES
('Shubham','Singh','Rampuri Colony','Saharanpur','UP',247001,7837373733,'shubham@gmail.com'),
('Rahul','Singh','Rampuri Colony','Saharanpur','UP',247001,7537737332,'rahul@gmail.com'),
('Dheeraj','Singh','Line Paar','Moradabad','UP',456363,8373737273,'dheeraj@gmail.com'),
('Shanu','Gupta','Hasanpur','Dehradun','UK',345233,7675747374,'shanu@gmail.com'),
('Yogesh','Upadhyay','Manak Mau','Roorkee','UK',373746,848838383,'yogesh@gmail.com')



