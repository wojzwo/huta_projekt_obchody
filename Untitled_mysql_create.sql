CREATE TABLE `Chip` (
	`chipId` varchar(31) NOT NULL,
	`isEmployee` BOOLEAN(1) NOT NULL,
	PRIMARY KEY (`chipId`)
);

CREATE TABLE `Employee` (
	`chipId` varchar(31) NOT NULL,
	`name` varchar(127) NOT NULL,
	PRIMARY KEY (`chipId`)
);

CREATE TABLE `Place` (
	`chipId` varchar(31) NOT NULL,
	`name` varchar(255) NOT NULL,
	`department` varchar(127) NOT NULL,
	PRIMARY KEY (`chipId`)
);

CREATE TABLE `Mark` (
	`id` INT NOT NULL,
	`description` varchar(127) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Track` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`name` varchar(255) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `TrackPlace` (
	`trackId` INT NOT NULL,
	`placeId` varchar(31) NOT NULL,
	PRIMARY KEY (`trackId`,`placeId`)
);

CREATE TABLE `Team` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`name` varchar(127) NOT NULL,
	`shift` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `TeamEmployee` (
	`teamId` INT NOT NULL,
	`employeeId` varchar(31) NOT NULL,
	PRIMARY KEY (`teamId`,`employeeId`)
);

CREATE TABLE `Routine` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`trackId` INT NOT NULL,
	`teamId` INT NOT NULL,
	`startDay` DATE NOT NULL,
	`cycleLength` INT NOT NULL,
	`cycleMask` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Report` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`routineId` INT NOT NULL,
	`assignmentDate` DATE NOT NULL,
	`signedEmployeeName` varchar(127) NOT NULL,
	`trackName` varchar(255) NOT NULL,
	`shift` INT NOT NULL,
	`isFinished` BOOLEAN(1) NOT NULL,
	`isRepeating` BOOLEAN(1) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ReportPlace` (
	`reportId` INT NOT NULL,
	`placeName` varchar(255) NOT NULL,
	`status` varchar(127) NOT NULL,
	`markDescription` varchar(127) NOT NULL,
	`comment` varchar(511) NOT NULL,
	PRIMARY KEY (`reportId`,`placeName`)
);

CREATE TABLE `ArchiveReport` (

);

CREATE TABLE `ArchiveReportPlace` (

);

ALTER TABLE `Employee` ADD CONSTRAINT `Employee_fk0` FOREIGN KEY (`chipId`) REFERENCES `Chip`(`chipId`);

ALTER TABLE `Place` ADD CONSTRAINT `Place_fk0` FOREIGN KEY (`chipId`) REFERENCES `Chip`(`chipId`);

ALTER TABLE `TrackPlace` ADD CONSTRAINT `TrackPlace_fk0` FOREIGN KEY (`trackId`) REFERENCES `Track`(`id`);

ALTER TABLE `TrackPlace` ADD CONSTRAINT `TrackPlace_fk1` FOREIGN KEY (`placeId`) REFERENCES `Place`(`chipId`);

ALTER TABLE `TeamEmployee` ADD CONSTRAINT `TeamEmployee_fk0` FOREIGN KEY (`teamId`) REFERENCES `Team`(`id`);

ALTER TABLE `TeamEmployee` ADD CONSTRAINT `TeamEmployee_fk1` FOREIGN KEY (`employeeId`) REFERENCES `Employee`(`chipId`);

ALTER TABLE `Routine` ADD CONSTRAINT `Routine_fk0` FOREIGN KEY (`trackId`) REFERENCES `Track`(`id`);

ALTER TABLE `Routine` ADD CONSTRAINT `Routine_fk1` FOREIGN KEY (`teamId`) REFERENCES `Team`(`id`);

ALTER TABLE `Report` ADD CONSTRAINT `Report_fk0` FOREIGN KEY (`routineId`) REFERENCES `Routine`(`id`);

ALTER TABLE `ReportPlace` ADD CONSTRAINT `ReportPlace_fk0` FOREIGN KEY (`reportId`) REFERENCES `Report`(`id`);

