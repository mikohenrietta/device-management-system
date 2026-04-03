IF DB_ID('DeviceManagement') IS NOT NULL
BEGIN
	USE DeviceManagement;
	IF OBJECT_ID('Users', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Users)
	BEGIN
		INSERT INTO Users (Name, Email, PasswordHash, Role, Location) VALUES ('Anna Smith', 'annas@gmail.com', 'examplehash1', 'manager', 'office');
		INSERT INTO Users (Name, Email, PasswordHash, Role, Location) VALUES ('Ben Carpenter', 'cben@gmail.com', 'examplehash2', 'software developer', 'home');
		INSERT INTO Users (Name, Email, PasswordHash, Role, Location) VALUES ('Lily Jenner', 'lilyjenner01@gmail.com', 'examplehash3', 'recruiter', 'office');
		INSERT INTO Users (Name, Email, PasswordHash, Role, Location) VALUES ('Devon Black', 'devbl@gmail.com', 'examplehash4', 'test engineer', 'office');
	END
	IF OBJECT_ID('Devices', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Devices)
	BEGIN
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('iPhone 15 Pro', 'Apple', 'Smartphone', 'iOS', '17.0', 'A17 Pro', '8');
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('ThinkPad X1 Carbon Gen 11', 'Lenovo', 'Laptop', 'Windows', '11.0', 'Intel Core i7-1355U', '32');
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('Mac Studio', 'Apple', 'Desktop', 'macOS', 'Sonoma', 'M2 Ultra', '128');
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('Galaxy Tab S9 Ultra', 'Samsung', 'Tablet', 'Android', '13.0', 'Snapdragon 8 Gen 2', '12');
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('PowerEdge R760', 'Dell', 'Server', 'Ubuntu Server', '22.04 LTS', 'Dual Intel Xeon Gold 6430', '512');
		INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OSVersion, Processor, RAMAmount) VALUES ('Steam Deck OLED', 'Valve', 'Handheld Console', 'SteamOS', '3.5', 'Custom AMD APU', '16');
	END
	IF OBJECT_ID('DeviceAssignments', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM DeviceAssignments)
	BEGIN
		INSERT INTO DeviceAssignments (UserID, DeviceID) VALUES (1, 1);
		INSERT INTO DeviceAssignments (UserID, DeviceID) VALUES (2, 4);
		INSERT INTO DeviceAssignments (UserID, DeviceID) VALUES (3, 2);
		INSERT INTO DeviceAssignments (UserID, DeviceID) VALUES (3, 3);
	END
END
